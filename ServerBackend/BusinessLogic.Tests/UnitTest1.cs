using System;
using GameCoreLibrary;
using Newtonsoft.Json;
using Xunit;

namespace BusinessLogic.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var level = new Level
            {
                GameObjects = new IGameObject[]
                {
                    new StaticObject
                    {
                        ObjectType = ObjectType.Platform,
                        HitPoints = 10,
                        HealthPoints = 19,
                    },
                    new Enemy
                    {
                        Id = Guid.NewGuid()
                    }, 
                    
                    
                }
            };
            var gameLevel = new GameLevel(level);
            var serialized = JsonConvert.SerializeObject(gameLevel);
            var deserialized = new GameLevelDeserializer();
            deserialized.Deserialize(serialized);


        }
    }
}