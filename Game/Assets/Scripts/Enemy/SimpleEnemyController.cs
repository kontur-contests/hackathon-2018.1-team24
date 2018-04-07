using Assets.Scripts.Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemyController :  EnemyBase
{
    public EnemyParams enemyParams;
    public ParticleSystem particles;

    void Start()
    {
        Set(enemyParams.speed, enemyParams.hit, enemyParams.hp);
        OnChangeHP += Onchage;
    }

    private void Onchage()
    {
        particles.Play();
        if (IsAlive == false) Destroy(gameObject);
    }
}
