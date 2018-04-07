using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float maxSpeed = 5f;
    public float jumpSpeed = 30f;

    private bool jump;

    private Transform groundCheck;
    private bool grounded = false;

    public PlayerPhysics playerPhysics;

    private void Start()
    {
        playerPhysics = GetComponent<PlayerPhysics>();
        groundCheck = transform.Find("groundCheck");
    }

    private void Update()
    {
        var move = new Vector2(Input.GetAxis("Horizontal") * Time.deltaTime * maxSpeed, playerPhysics.rig.velocity.y);

        //даем силу движения игроку
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        if ((Input.GetKeyDown(KeyCode.W) || Input.GetMouseButton(0)) && grounded)
        {
            playerPhysics.rig.AddForce(Vector2.up * jumpSpeed);
        }



        playerPhysics.rig.velocity = move;
    }

}
