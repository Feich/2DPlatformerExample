using System;
using UnityEngine;

public class PlayerJumpState : IState
{
    public void OnUpdate(SimplePlayerController fsm)
    {
        if (fsm.IsGrounded())
        {
            // transition back to idle when back on ground
            fsm.Transition(SimplePlayerController.IdleState);
        }
    }

    public void OnEnter(SimplePlayerController fsm)
    {
        fsm.Jump();
        Debug.Log("Jump State Enter");
    }

    public void OnExit(SimplePlayerController fsm)
    {
        Debug.Log("Jump State Exit");
    }
}
