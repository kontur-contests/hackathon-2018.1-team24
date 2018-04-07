using Assets.Scripts.Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemyController :  EnemyBase
{
    public float speed;
    public float hp;
    public float hit;

    public ParticleSystem particle;

    void Start()
    {
        Set(speed, hit, hp);
        OnChangeHP += Onchage;
    }

    private void Onchage()
    {
        particle.Play();
        if (IsAlive == false) Destroy(gameObject);
    }

    void Update()
    {

    }
}
