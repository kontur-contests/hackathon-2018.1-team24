using System;
using System.Linq;
using FluentAssertions;
using GameCoreLibrary;
using Newtonsoft.Json;
using Xunit;

namespace BusinessLogic.Tests
{
    public class BusinessLogicTests
    {
        [Fact]
        public void Deserialized_Level()
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

        [Fact]
        public void SyncLevelOnExistingFloor()
        {
            var g = Guid.Parse("E5106651-DFD4-45B3-BE3A-21B4F97A35AA");
            var g2 = Guid.Parse("E5106651-DFD4-45B3-BE3A-21B4F97A35AB");
            var lvl = new GameLevel(new Level())
            {
                LevelFloor = LevelFloor.Entrance,
                GameObjects = new IGameObject[]
                {
                    new Player(){Id =  new Guid("E5106651-DFD4-45B3-BE3A-21B4F97A35A1")},
                    new Enemy()
                    {
                        Id = g,
                        Pos = new Pos(202, 30),
                        HealthPoints = 20,
                        MoveRange = 10
                    },
                    new Enemy()
                    {
                        Id = g2,
                        Pos = new Pos(503, 40),
                        HealthPoints = 20,
                        ObjectType = ObjectType.Bitcoin,
                        MoveRange = 10
                    }
                }.ToList()
            };

            var oldLvl = new GameLevel(new Level())
            {
                LevelFloor = LevelFloor.Entrance,
                GameObjects = new IGameObject[]
                {
                    new Player(){Id =  new Guid("E5106651-DFD4-45B3-BE3A-21B4F97A35A1")}, 
                    new Enemy
                    {
                        Id = g,
                        Pos = new Pos(200, 30),
                        HealthPoints = 40,
                        ObjectType = ObjectType.Cacti,
                        MoveRange = 20
                    },
                    new Enemy
                    {
                        Id = Guid.NewGuid(),
                        Pos = new Pos(500, 40),
                        ObjectType = ObjectType.Bug,
                        HealthPoints = 20,
                        MoveRange = 20
                    }
                }.ToList()
            };

            oldLvl.DoSync(lvl);

            Assert.Equal(LevelFloor.Entrance, oldLvl.LevelFloor);

            oldLvl.GameObjects.OrderByDescending(x=>x.Id).Should().BeEquivalentTo(new IGameObject[]
            {
                new Player(){Id =  new Guid("E5106651-DFD4-45B3-BE3A-21B4F97A35A1")},
                new Enemy()
                {
                    Id = g,
                    Pos = new Pos(202, 30),
                    HealthPoints = 20,
                    ObjectType = ObjectType.Cacti,
                    MoveRange = 20
                },
                new Enemy()
                {
                    Id = g2,
                    Pos = new Pos(503, 40),
                    HealthPoints = 20,
                    ObjectType = ObjectType.Bitcoin,
                    MoveRange = 10
                }
            }.OrderByDescending(x => x.Id), o => o.Excluding(x=>x.Id).ExcludingMissingMembers());
        }
    }
}