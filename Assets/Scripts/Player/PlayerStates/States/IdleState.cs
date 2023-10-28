using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : PlayerState
{
    public IdleState(StateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter(object param = null)
    {
        Name = "IdlingState";
        _playerMoverView.SetAnimation("AnimState", 0);

        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void HandleInput()
    {
        base.HandleInput();

        if (Horizontal != 0 || Vertical != 0)
        {
            stateMachine.ChangeState(PlayerStateEnum.Walk);
        }
        //if (Input.GetKeyDown(KeyCode.F))
        //{
        //    stateMachine.ChangeState(PlayerStateEnum.Searching);
        //}
        //if (Input.GetMouseButtonDown(0))
        //{
        //    var pos = InputHandler.MousePosition;
        //    stateMachine.ChangeState(PlayerStateEnum.Digging, pos);
        //}
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
