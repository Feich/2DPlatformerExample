using System;
using UnityEngine;

public class PlayerRunState : IState
{
    public void OnUpdate(SimplePlayerController fsm)
    {
        if (Mathf.Abs(Input.GetAxis("Horizontal")) < 0.0001f)
        {
            fsm.Transition(SimplePlayerController.IdleState);
        }
        if (Input.GetButtonDown("Jump") && fsm.IsGrounded())
        {
            fsm.Transition(SimplePlayerController.JumpState);
        }
    }

    public void OnEnter(SimplePlayerController fsm)
    {
        Debug.Log("Run State Enter");
    }

    public void OnExit(SimplePlayerController fsm)
    {
        Debug.Log("Run State Exit");
    }
}
