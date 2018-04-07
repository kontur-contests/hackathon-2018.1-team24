using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float maxSpeed = 5f;
    public float jumpSpeed = 30f;

    public bool jump { get; private set; }
    public bool walk { get; private set; }

    private Transform groundCheck;
    private bool grounded = false;

    public Rigidbody2D rig;

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        groundCheck = transform.Find("groundCheck");
    }

    private void Update()
    {
        var move = new Vector2(Input.GetAxis("Horizontal") * Time.deltaTime * maxSpeed, rig.velocity.y);

        //даем силу движения игроку
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetMouseButtonDown(0)) && grounded)
        {
            rig.AddForce(Vector2.up * jumpSpeed);
        }
        
        rig.velocity = move;

        walk = Mathf.Abs(move.x) == 0 ? false : true;
    }

}
