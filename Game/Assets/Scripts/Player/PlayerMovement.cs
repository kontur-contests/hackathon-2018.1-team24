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

    public GameObject leftButton;
    public GameObject rightButton;
    public GameObject upButton;

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        groundCheck = transform.Find("groundCheck");
    }

    private void Update()
    {
        var move = new Vector2(Input.GetAxis("Horizontal") * Time.deltaTime * maxSpeed, rig.velocity.y);

        var isUpButton = false;

        var hits = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward);
        foreach (var hit in hits)
        {
            if (hit.collider != null)
            {
                if (Input.GetMouseButton(0))
                {
                    if (hit.collider.gameObject == leftButton) move = new Vector2(-1f * Time.deltaTime * maxSpeed, rig.velocity.y);
                    if (hit.collider.gameObject == rightButton) move = new Vector2(1f * Time.deltaTime * maxSpeed, rig.velocity.y);
                }
                if (Input.GetMouseButtonDown(0))
                {
                    if (hit.collider.gameObject == upButton) isUpButton = true;
                }
            }
        }

        //даем силу движения игроку
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        
        if ((Input.GetKeyDown(KeyCode.W) || isUpButton) && grounded)
        {
            rig.AddForce(Vector2.up * jumpSpeed);
        }
        
        rig.velocity = move;

        walk = Mathf.Abs(move.x) == 0 ? false : true;
    }

}
