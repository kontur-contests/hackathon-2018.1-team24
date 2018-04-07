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
                Speed = 0,
                ObjectType = ObjectType.Guard
            };
        }

        public static Enemy NewClawn()
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
                MoveRange = 20,
                ObjectType = ObjectType.Clawn
            };
        }

        public static Enemy NewCacti(int x)
        {
            return new Enemy()
            {
                Pos = new Pos(x, -2),
                MaxHealthPoints = 60,
                HitPoints = 4,
                HealthPoints = 60,
                Id = Guid.NewGuid(),
                Reward = 2,
                MoveRange = 30,
                Speed = 0,
                ObjectType = ObjectType.Cacti
            };
        }

        public static Enemy NewItem()
        {
            return new Enemy()
            {
                Pos = new Pos(-60, -2),
                MaxHealthPoints = 50,
                HitPoints = 3,
                MoveRange = 20,
                HealthPoints = 50,
                Id = Guid.NewGuid(),
                Reward = 2,
                Speed = 0,
                ObjectType = ObjectType.Guard
            };
        }


        public static Enemy NewBug(int xCoord)
        {
            
                return new Enemy
                {
                    Pos = new Pos(xCoord, -3),
                    MaxHealthPoints = 20,
                    HitPoints = 2,
                    HealthPoints = 20,
                    Id = Guid.NewGuid(),
                    Reward = 1,
                    Speed = 1,
                    MoveRange = 10,
                    ObjectType = ObjectType.Bug
                };
        }

        public static IEnumerable<Enemy> NewBugsLevel1()
        {
            foreach (var xCoord in new[]{-45,-15, 48, 70})
            {
                yield return NewBug(xCoord);
            }
            
        }
    }
}