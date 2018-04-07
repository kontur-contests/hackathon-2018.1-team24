using System;

namespace GameCoreLibrary
{
    public abstract class BaseGameObject : IGameObject
    {
        public Guid Id { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public bool IsAlive { get; set; }
    }
}