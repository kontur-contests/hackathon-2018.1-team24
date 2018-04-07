using System;

namespace GameCoreLibrary
{
    public interface IGameObject 
    {
        Guid Id { get; set; }
        float X { get; set; }
        float Y { get; set; }
        bool IsAlive { get; set; }
        int HealthPoints { get; set; }
        int HitPoints { get; set; }
        int Hit();

        IGameObject Clone();
    }
}