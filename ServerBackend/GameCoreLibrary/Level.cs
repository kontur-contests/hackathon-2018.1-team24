using System.Collections.Generic;

namespace GameCoreLibrary
{
    public class Level
    {
        public IGameObject[] GameObjects { get; set; }
        public LevelFloor LevelFloor { get; set; }
    }
}