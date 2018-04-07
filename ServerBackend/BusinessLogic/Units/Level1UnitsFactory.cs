using System;
using System.Collections.Generic;
using GameCoreLibrary;

namespace BusinessLogic.Units
{
    public static class UnitsFactory
    {
        public static Enemy NewGuard()
        {
            return new Enemy()
            {
                Pos = new Pos(-60, -2),
                MaxHealthPoints = 50,
                HitPoints = 3,
                HealthPoints = 50,
                Id = Guid.NewGuid(),
                Reward = 2,
                Speed = 2,
                ObjectType = ObjectType.Guard
            };
        }

        public static Enemy NewKachok()
        {
            return new Enemy()
            {
                Pos = new Pos(20, -3),
                MaxHealthPoints = 70,
                HitPoints = 6,
                HealthPoints = 70,
                Id = Guid.NewGuid(),
                Reward = 3,
                Speed = 2,
                ObjectType = ObjectType.Guard
            };
        }

        public static IEnumerable<Enemy> NewBugsLevel1()
        {
            foreach (var xCoord in new[]{-45,-15, 48, 70})
            {
                yield return new Enemy
                {
                    Pos = new Pos(xCoord, -3),
                    MaxHealthPoints = 20,
                    HitPoints = 2,
                    HealthPoints = 20,
                    Id = Guid.NewGuid(),
                    Reward = 1,
                    Speed = 1,
                    ObjectType = ObjectType.Bug
                };
            }
            
        }
    }
}