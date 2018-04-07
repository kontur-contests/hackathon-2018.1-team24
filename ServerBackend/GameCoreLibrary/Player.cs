using System.Collections.Generic;

namespace GameCoreLibrary
{
    public class Player : BaseGameObject
    {
        public const int HitRange = 100;

        public string PlayerName { get; set; }
        public int Score { get; set; }

        public List<Modificator> Modificators { get; set; }
        public int BaseHitPoints { get; set; }
        public float Speed { get; set; }

        public List<Skill> Skills { get; set; }

        public override ObjectType ObjectType
        {
            get => ObjectType.Player;
            set { }
        }
    }
}