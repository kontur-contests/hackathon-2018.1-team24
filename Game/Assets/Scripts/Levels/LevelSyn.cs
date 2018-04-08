using GameCoreLibrary;
using System;
using UnityEngine;
using WebSocketSharp;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

public class LevelSyn : MonoBehaviour
{

    public PlayerState playerState;

    public WebSocket socket;
    public string url;
    public bool isConnected;

    public PlayerController playerController;
    public LevelFloor levelFloor;

    [Range(1, 30)]
    public float rate;

    public List<PlayerSync> players;

    public GameObject prefabPlayer;

    public List<List<PlayerState>> syncs;

    private void Start()
    {
        syncs = new List<List<PlayerState>>();
        playerState = new PlayerState();
        var g = Guid.NewGuid();
        playerState.PlayerId = g;

        socket = new WebSocket(url);
        
        socket.OnOpen += OnOpen;
        socket.OnClose += OnClose;
        socket.OnMessage += OnMessage;

        socket.Connect();

        InvokeRepeating("Send", 1f / rate, 1f / rate);

    }

    private void OnDestroy()
    {
        if (socket != null)
        {
            if (isConnected) socket.Close();
        }
    }

    public void Send()
    {
        if (isConnected)
        {
            playerState.Level = levelFloor;
            playerState.X = playerController.transform.position.x;
            playerState.Y = playerController.transform.position.y;
            playerState.Job = !playerController.playerMovement.walk && !playerController.isAttack ? 0 : playerController.playerMovement.walk ? 1 : playerController.isAttack ? 2 : 0;
            playerState.IsAlive = playerController.IsAlive;

           var json = JsonConvert.SerializeObject(playerState);
           socket.Send(json);
        }
    }

    private void OnOpen(object sender, EventArgs args)
    {
        isConnected = true;
        print("Открыли");
    }

    private void OnClose(object sender, EventArgs args)
    {
        isConnected = false;
        print("Закрыто");
    }

    private void OnMessage(object sender, MessageEventArgs e)
    {
        if (e.IsText)
        {
            lock (syncs)
            {
                var listStats = JsonConvert.DeserializeObject<List<PlayerState>>(e.Data);
                syncs.Add(listStats);
            }
        }
    }

    private void FixedUpdate()
    {
        lock (syncs)
        {
            if (syncs.Count > 0)
            {
                var listStats = syncs[0];
                var removeList = new List<PlayerSync>();

                foreach (var state in listStats)
                {
                    var objs = FindObjectsOfType<PlayerSync>();
                    var find = false;
                    if (state.PlayerId != playerState.PlayerId)
                    {
                        foreach (var obj in objs)
                        {
                            if (obj.playerState.PlayerId == state.PlayerId)
                            {
                                obj.UpdateState(state, rate);
                                find = true;
                            }
                        }
                        if (!find)
                        {
                            var player = Instantiate(prefabPlayer, new Vector3(state.X, state.Y), Quaternion.identity).GetComponent<PlayerSync>();
                            player.UpdateState(state, rate);
                            players.Add(player);
                        }
                    }
                }


                //foreach (var player in FindObjectsOfType<PlayerSync>())
                //{
                //    var item = listStats.Find(x => x.PlayerId == player.playerState.PlayerId);
                //    if (item == null) removeList.Add(player);
                //}

                //foreach (var remove in removeList)
                //{
                //    Destroy(remove.gameObject);
                //    players.Remove(remove);
                //}
                syncs.RemoveAt(0);
            }
        }
    }

}
