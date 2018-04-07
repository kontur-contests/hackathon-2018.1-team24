using System;

namespace GameCoreLibrary
{
    public class PlayerState
    {
        public LevelFloor Level { get; set; }
        public Guid PlayerId { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public bool IsAlive { get; set; }
        public int Job { get; set; }
    }
}