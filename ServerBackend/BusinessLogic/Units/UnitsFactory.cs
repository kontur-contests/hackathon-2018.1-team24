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
                Pos = new Pos(300, 90),
                MaxHealthPoints = 100,
                HitPoints = 100,
                HealthPoints = 100,
                Id = Guid.NewGuid(),
                Reward = 1,
                Speed = 2,
                ObjectType = ObjectType.Guard
            };
        }
    }
}