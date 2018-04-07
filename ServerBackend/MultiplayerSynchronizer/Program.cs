using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using Fleck;
using GameCoreLibrary;
using Newtonsoft.Json;

namespace MultiplayerSynchronizer
{
    class Program
    {
        private static List<IWebSocketConnection> _webSocketConnections;
        private static ConcurrentDictionary<Guid, (IWebSocketConnection, PlayerState)> webSocketConnections;


        private static Timer timer = new Timer(300);

        static void Main(string[] args)
        {
            webSocketConnections = new ConcurrentDictionary<Guid, (IWebSocketConnection, PlayerState)>();
            var server = new WebSocketServer("ws://0.0.0.0:8181");
            _webSocketConnections = new List<IWebSocketConnection>();
            timer.Start();
            timer.Elapsed += TimerElapsed;
            server.Start(socket =>
            {
                socket.OnOpen = () =>
                {
                    Console.WriteLine("Open!");
                    _webSocketConnections.Add(socket);
                };
                socket.OnClose = () =>
                {
                    Console.WriteLine("Close!");
                    StateStorage.Delete(socket);
                    _webSocketConnections.Remove(socket);
                };
                socket.OnMessage = message => { MessageReceived(socket, message); };
            });
            var input = Console.ReadLine();
        }

        private static void TimerElapsed(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            foreach (var state in StateStorage.playerStates)
            {
                var states = state.Value.Select(x => x.Value.Item2).ToArray();
                var toSend = JsonConvert.SerializeObject(states);
                foreach (var tuple in state.Value)
                {
                    tuple.Value.Item1.Send(toSend).ConfigureAwait(false);
                }
            }
            timer.Start();
        }


        private static void MessageReceived(IWebSocketConnection socket, string message)
        {
            try
            {
                var deserialized = (PlayerState)JsonConvert.DeserializeObject(message);

                StateStorage.UpdateOrAdd(socket, deserialized);
            }
            catch (Exception)
            {

            }
            

        }

        public static class StateStorage
        {
            public static ConcurrentDictionary<int, Dictionary<Guid, (IWebSocketConnection, PlayerState)>> playerStates =
                new ConcurrentDictionary<int, Dictionary<Guid, (IWebSocketConnection, PlayerState)>>();


            public static void Delete(IWebSocketConnection socketConnection)
            {
                lock (playerStates)
                {
                    try
                    {
                        var dictionary = playerStates.FirstOrDefault(x => x.Value.Any(y => y.Key == socketConnection.ConnectionInfo.Id));

                        var state = dictionary.Value.FirstOrDefault(x => x.Key == socketConnection.ConnectionInfo.Id);
                        dictionary.Value.Remove(state.Key);
                    }
                    catch(Exception e)
                    {

                    }
                }
            }

            public static void UpdateOrAdd(IWebSocketConnection webSocketConnection, PlayerState playerState)
            {
                var level = (int) playerState.Level;
                lock (playerStates)
                {
                    if (!playerStates.ContainsKey(level))
                    {
                        playerStates[level] = new Dictionary<Guid, (IWebSocketConnection, PlayerState)>();
                    }
                }

                lock (playerStates[level])
                {
                    var playerStateLevels = playerStates[level];
                    playerStateLevels[webSocketConnection.ConnectionInfo.Id] = (webSocketConnection,playerState);
                }
            }
        }
    }
}