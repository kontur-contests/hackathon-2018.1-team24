
using System;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public abstract class EnemyBase: MonoBehaviour
    {
        public void Set(double speed, double hit, double hp)
        {
            Speed = speed;
            Hit = hit;
            Hp = hp;
            MaxHp = Hp;
        }

        public double Speed { get; private set; }
        public double Hit { get; private set; }
        public double Hp { get; private set; }
        public double MaxHp { get; private set; }
        public Action OnChangeHP = delegate { };

        public bool IsAlive
        {
            get { return Hp > 0; }
        }

        public void ApplyHit(double hit)
        {
            Hp -= hit;
            OnChangeHP();
            Debug.LogFormat("Жизня: {0} Жив: {1}", Hp, IsAlive);
        }
    }
}