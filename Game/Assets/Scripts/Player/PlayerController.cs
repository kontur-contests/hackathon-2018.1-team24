using Assets.Scripts.Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : EnemyBase
{
    public EnemyParams enemyParams;
    public PlayerMovement playerMovement;
    private Animator anim;
    public ParticleSystem particle;
    public bool isAttack;
    private float release;

    public GameObject punchButton;

    void Start ()
    {
        playerMovement = GetComponent<PlayerMovement>();
        anim = GetComponent<Animator>();
        Set(enemyParams.speed, enemyParams.hit, enemyParams.hp);
        OnChangeHP += delegate { particle.Play(); if (!IsAlive) Application.LoadLevel("GameOver"); PlayerHPBar.Instance?.Set(1f - (float) (Hp / MaxHp)); };
	}

    void Update()
    {

        anim.SetBool("Run", playerMovement.walk);

        var punch = false;
        if (Input.GetMouseButtonDown(0))
        {
            var hitsButton = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward);
            foreach (var hit in hitsButton)
            {
                if (hit.collider != null)
                {
                    if (hit.collider.gameObject == punchButton) punch = true;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.RightControl) || punch)
        {
            anim.SetTrigger("Attack");
            isAttack = true;
            release = Time.time + 0.2f;
            var hits = Physics2D.LinecastAll(transform.position, transform.position + new Vector3(3f, 0));
            foreach (var hit in hits)
            {
                if (hit.collider != null && hit.collider.tag == "Enemy")
                {
                    var enemyBase = hit.collider.GetComponent<EnemyBase>();
                    enemyBase?.ApplyHit(5);
                    SoundManager.Instance.Play("punch");
                    break;
                }
            }
        }

        if (Time.time > release) isAttack = false;

	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bitcoin")
        {
            collision.GetComponent<ParticleSystem>()?.Play();
            foreach (Transform t in collision.transform)
            {
                var spr = t.GetComponent<SpriteRenderer>();
                if (spr != null) spr.sprite = null;
                BitcoinCountUI.Instance?.Add();
                Destroy(collision.gameObject, 1f);
                SoundManager.Instance.Play("coin");
            }
        }
        if (collision.tag == "Lift")
        {
            SoundManager.Instance.Play("lift");
            var levelNum = Application.loadedLevel;
            Application.LoadLevel(levelNum + 1);
        }
    }

}
