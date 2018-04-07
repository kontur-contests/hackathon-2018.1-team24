namespace Assets.Scripts.Enemy
{
    public abstract class EnemyBase
    {
        protected EnemyBase(double speed, double hit, double hp)
        {
            Speed = speed;
            Hit = hit;
            Hp = hp;
        }

        public double Speed { get; private set; }
        public double Hit { get; private set; }
        public double Hp { get; private set; }

        public bool IsAlive
        {
            get { return Hp > 0; }
        }

        public void ApplyHit(double hit)
        {
            Hp -= hit;
        }
    }
}