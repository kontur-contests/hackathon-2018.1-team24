using System.Collections.Generic;
using GameCoreLibrary;

namespace BusinessLogic
{
    public class LevelGenerator
    {
        
        public GameLevel[] GetStaticLevels()
        {
            //TODO много уровней
            return new[] {GenerateLevel((int) LevelFloor.Entrance)};
        }
        
        public GameLevel[] GenerateLevels()
        {
            //TODO много уровней
            return new[] {GenerateLevel((int) LevelFloor.Entrance)};
        }

        public GameLevel GenerateLevel(int levelNumber)
        {
            return new GameLevel(StaticLevels.levels[levelNumber]);
        }
    }

    public static class StaticLevels
    {
        public static Dictionary<int, Level> levels = new Dictionary<int, Level>
        {
            {
                1, new Level
                {
                    GameObjects = new[]
                    {
                        new StaticObject
                        {
                            ObjectType = ObjectType.Platform,
                            HitPoints = 20,
                            HealthPoints = 30,
                            IsAlive = true,
                            X = 20,
                            Y = 20,
                        },
                        new StaticObject
                        {
                            ObjectType = ObjectType.Platform,
                            HitPoints = 20,
                            HealthPoints = 30,
                            IsAlive = true,
                            X = 200,
                            Y = 20,
                        },
                    }
                }
            }
        };
    }
}