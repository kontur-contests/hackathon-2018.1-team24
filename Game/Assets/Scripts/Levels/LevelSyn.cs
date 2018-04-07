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

    private void Start()
    {
        playerState = new PlayerState();
        playerState.PlayerId = new Guid();

        socket = new WebSocket(url);

        socket.OnOpen += OnOpen;
        socket.OnClose += OnClose;
        socket.OnMessage += OnMessage;

        InvokeRepeating("Send", 1f / rate, 1f / rate);

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
    }

    private void OnClose(object sender, EventArgs args)
    {
        isConnected = false;
    }

    private void OnMessage(object sender, MessageEventArgs e)
    {
        if (e.IsText)
        {
            var list = JsonConvert.DeserializeObject<List<PlayerState>>(e.Data);
            var addList = new List<PlayerState>();
            var removeList = new List<PlayerSync>();

            foreach (var p in players)
            {
                var item = list.Find(x => x.PlayerId == p.playerState.PlayerId);
                if (item == null)
                {
                    addList.Add(item);
                    p.UpdateState(item, rate);
                }
            }

            foreach (var p in list)
            {
                var item = players.Find(x => x.playerState.PlayerId == p.PlayerId);
                if (item != null) removeList.Add(item);
            }

            foreach (var state in addList)
            {
                var player = Instantiate(prefabPlayer, new Vector3(state.X, state.Y), Quaternion.identity).GetComponent<PlayerSync>();
                player.UpdateState(state, rate);
                players.Add(player);
            }

            foreach (var remove in removeList)
            {
                Destroy(remove.gameObject);
                players.Remove(remove);
            }
        }
    }

}
