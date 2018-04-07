using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysics : MonoBehaviour {

    public Rigidbody2D rig;
	void Awake ()
    {
        rig = GetComponent<Rigidbody2D>();
	}


    public void Move(Vector2 moveAmount, bool jump)
    {
        if (jump)
        {
            rig.AddForce(new Vector2(0, 50));
        }
        var pos = new Vector2(rig.position.x + moveAmount.x, rig.position.y + moveAmount.y + Physics2D.gravity.y * Time.deltaTime);
        //rig.MovePosition(pos);
    }

	void Update () {
		
	}
}
