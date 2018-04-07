using Assets.Scripts.Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : EnemyBase
{
    public PlayerMovement playerMovement;
    private Animator anim;
    public ParticleSystem particle;

	void Start ()
    {
        playerMovement = GetComponent<PlayerMovement>();
        anim = GetComponent<Animator>();
        Set(0, 5, 50);
        OnChangeHP += delegate { particle.Play(); if (!IsAlive) Destroy(gameObject); };
	}

    void Update()
    {

        anim.SetBool("Run", playerMovement.walk);
        

        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            anim.SetTrigger("Attack");
            var hits = Physics2D.LinecastAll(transform.position, transform.position + new Vector3(3f, 0));
            foreach (var hit in hits)
            {
                if (hit.collider != null && hit.collider.tag == "Enemy")
                {
                    var enemyBase = hit.collider.GetComponent<EnemyBase>();
                    enemyBase?.ApplyHit(5);
                    break;
                }
            }
        }
        
	}
}
