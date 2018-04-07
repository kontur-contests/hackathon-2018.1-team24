using GameCoreLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerSync : MonoBehaviour
{

    public PlayerState playerState;
    public Animator anim;

    public Vector2 oldPosition;
    public Vector2 newPosition;
    public float newTime;
    public float rateTime;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void UpdateState(PlayerState state, float rate)
    {
        playerState = state;
        rateTime = 1f / rate;
        newTime = Time.time + rateTime;
        oldPosition = transform.position;
        newPosition = new Vector2(state.X, state.Y);
        if (anim != null)
        {
            anim.SetBool("Run", playerState.Job == 1);
            if (playerState.Job == 2) anim.SetTrigger("Attack");
        }
    }

    private void Update()
    {
        var t = 1f -(newTime - Time.time) / rateTime;
        transform.position = Vector2.Lerp(oldPosition, newPosition, t);
    }

}

