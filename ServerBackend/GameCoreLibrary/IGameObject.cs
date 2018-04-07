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
        float X { get; set; }
        float Y { get; set; }
        int HealthPoints { get; set; }
        int MaxHealthPoints { get; set; }
        double HealthPercent { get; }

        int HitPoints { get; set; }

        double Speed { get; set; }
        int Reward { get; set; }

        double MoveRange { get; set; }

        bool Hit(IGameObject gameObject);
        IGameObject Clone();
    }
}