using System.Collections.Generic;
using System.Linq;

namespace GameCoreLibrary
{
    public class GameLevel
    {
        public List<IGameObject> GameObjects { get; set; }

        public GameLevel(Level level)
        {
            GameObjects = level.GameObjects.Select(x => x.Clone()).ToList();
        }
    }
}