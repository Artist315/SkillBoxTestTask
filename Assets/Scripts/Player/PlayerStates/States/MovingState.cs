using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingState : PlayerState
{
    protected MovingState(StateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter(object param = null)
    {
        Name = "WalkingState";
        _playerMoverView.SetAnimation("AnimState", 2);

        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }
}
