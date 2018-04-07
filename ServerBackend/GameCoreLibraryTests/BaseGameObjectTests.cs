using System;
using FluentAssertions;
using GameCoreLibrary;
using Xunit;

namespace GameCoreLibraryTests
{
    public class BaseGameObjectTests
    {
        [Fact]
        public void CloneAnyObject()
        {
            var player = new Player
            {
                BaseHitPoints = 123,
                HealthPoints = 345,
                IsAlive = true,
                PlayerName = "ololo",
                Score = 12345,
                Speed = 12345,
                X = 12344,
                Y = 123455,
                HitPoints = 1221,
                Id = Guid.NewGuid(),
            };
            var newPlayer = player.Clone();
            newPlayer.Should().BeEquivalentTo(player,x => x.Excluding(y => y.Id));
            newPlayer.Id.Should().NotBe(player.Id);
            
        }
    }
}