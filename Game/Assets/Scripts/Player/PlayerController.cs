using Assets.Scripts.Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


    public PlayerMovement playerMovement;
    private Animator anim;

	void Start ()
    {
        playerMovement = GetComponent<PlayerMovement>();
        anim = GetComponent<Animator>();
	}

    void Update()
    {

        anim.SetBool("run", playerMovement.walk);
        

        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            anim.SetTrigger("attack");
            var hits = Physics2D.LinecastAll(transform.position + transform.position + new Vector3(5f, 0), transform.position + new Vector3(10f, 0));
            foreach (var hit in hits)
            {
                if (hit.collider != null && hit.collider.tag == "Enemy")
                {
                    var enemyBase = hit.collider.GetComponent<EnemyController>();
                    enemyBase.ApplyHit(5);
                    break;
                }
                else if (hit.collider != null) print(hit.collider.tag);
            }
        }
        
	}
}
