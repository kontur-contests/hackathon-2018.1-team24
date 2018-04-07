using System;
using GameCoreLibrary;

namespace BusinessLogic.Units
{
    public static class UnitsFactory
    {
        public static Enemy NewGuard()
        {
            return new Enemy()
            {
                Pos = new Pos(-2, -3),
                MaxHealthPoints = 50,
                HitPoints = 3,
                HealthPoints = 50,
                Id = Guid.NewGuid(),
                Reward = 1,
                Speed = 2,
                ObjectType = ObjectType.Guard
            };
        }

        public static Enemy NewKachok()
        {
            return new Enemy()
            {
                Pos = new Pos(90, -3),
                MaxHealthPoints = 70,
                HitPoints = 6,
                HealthPoints = 90,
                Id = Guid.NewGuid(),
                Reward = 1,
                Speed = 2,
                ObjectType = ObjectType.Guard
            };
        }

        public static Enemy NewBugs()
        {
            return new Enemy()
            {
                Pos = new Pos(90, -3),
                MaxHealthPoints = 70,
                HitPoints = 6,
                HealthPoints = 90,
                Id = Guid.NewGuid(),
                Reward = 1,
                Speed = 2,
                ObjectType = ObjectType.Bug
            };
        }
    }
}