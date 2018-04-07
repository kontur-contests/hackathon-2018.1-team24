using System;
using System.Linq;

namespace GameCoreLibrary
{
    public class Enemy : BaseGameObject
    {
        public override ObjectType ObjectType { get; set; }

        public Pos FindMove(GameLevel game, TimeSpan timeDelta)
        {
            var user =  game.GameObjects.OfType<Player>().OrderBy(x => x.Pos.DistTo(Pos)).FirstOrDefault();
            return Pos.MoveTowards(user.Pos, timeDelta.TotalSeconds * Speed);
        }
    }
}