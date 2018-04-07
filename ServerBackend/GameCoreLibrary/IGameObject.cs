using System;

namespace GameCoreLibrary
{
    public interface IGameObject
    {
        Guid Id { get; set; }
        float X { get; set; }
        float Y { get; set; }
        bool IsAlive { get; set; }
    }
}