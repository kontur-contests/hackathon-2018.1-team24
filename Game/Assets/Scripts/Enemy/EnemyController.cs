using Assets.Scripts.Enemy;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : SimpleEnemy 
{

    public float speed;
    public float hp;
    public float hit;

    public ParticleSystem particleSystem;

    void Start ()
    {
        Set(speed, hit, hp);
        OnChangeHP += Onchage;
	}

    private void Onchage()
    {
        particleSystem.Play();
        if (IsAlive == false) Destroy(gameObject);
    }

    void Update ()
    {
		
	}
}
