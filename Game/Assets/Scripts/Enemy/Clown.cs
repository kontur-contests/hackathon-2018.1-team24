using Assets.Scripts.Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clown : EnemyBase
{
    public float speed;
    public float hp;
    public float hit;

    public float distance;
    private Vector3 startPosition;
    private bool toRightDircetion;

    public ParticleSystem particleSystem;
    private float release;
    private Animator anim;

    void Start()
    {
        Set(speed, hit, hp);
        OnChangeHP += Onchage;
        startPosition = transform.position;
        anim = GetComponent<Animator>();
    }

    private void Onchage()
    {
        particleSystem.Play();
        if (IsAlive == false) Destroy(gameObject);
    }
    
    void Update ()
    {
        if (!toRightDircetion && (startPosition - transform.position).x < -distance) toRightDircetion = true;
        if (toRightDircetion && (startPosition - transform.position).x > distance) toRightDircetion = false;

        bool attack = false;
        
        var hits = Physics2D.CircleCastAll(transform.position, 3f, Vector2.zero);
        foreach (var hit in hits)
        {
            if (hit.collider != null && hit.collider.tag == "Player")
            {
                attack = true;
                if (release < Time.time)
                {
                    var enemyBase = hit.collider.GetComponent<EnemyBase>();
                    enemyBase.ApplyHit(5);
                    release = Time.time + 2f;
                    anim.SetTrigger("Attack");
                }
                break;
            }
        }

        if (!attack)
        {
            anim.SetBool("Run", true);
            transform.position = !toRightDircetion ? transform.position + new Vector3(speed, 0f) * Time.deltaTime : transform.position - new Vector3(speed, 0f) * Time.deltaTime;
        }
        else
        {
            anim.SetBool("Run", false);
        }
    }
}
