using System.Collections.Generic;

namespace GameCoreLibrary
{
    public class LevelState
    {
        public List<Player> Players { get; set; }
        public List<IGameObject> GameObjects { get; set; }
    }
}