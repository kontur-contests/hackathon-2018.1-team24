using System;

namespace GameCoreLibrary
{
    public interface IGameObject
    {
        Guid Id { get; set; }
        Pos Pos { get; set; }
        bool IsAlive { get; }
        int HealthPoints { get; set; }
        int HitPoints { get; set; }
        int Reward { get; set; }
        int Hit(IGameObject gameObject);
        IGameObject Clone();
    }
}