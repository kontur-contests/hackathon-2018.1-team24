using System;

namespace GameCoreLibrary
{
    public interface IGameObject
    {
        Guid Id { get; set; }

        ObjectType ObjectType
        {
            get;
        }
        bool IsAlive { get; }
        Pos Pos { get; set; }
        int HealthPoints { get; set; }
        int MaxHealthPoints { get; set; }
        double HealthPercent { get; }

        int HitPoints { get; set; }
        
        int Speed { get; set; }
        int Reward { get; set; }

        bool Hit(IGameObject gameObject);
        IGameObject Clone();
    }
}