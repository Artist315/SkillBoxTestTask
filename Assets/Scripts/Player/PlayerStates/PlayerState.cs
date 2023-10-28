using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected StateMachine stateMachine;
    protected readonly PlayerMoverView _playerMoverView;
    protected readonly Player _player;


    public string Name;
    public float Horizontal;
    public float Vertical;
    public Vector3 MousePos;

    protected PlayerState(StateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
        _player = Player.Instance;
        _playerMoverView = _player._playerMoverView;
    }

    public virtual void Enter(object param = null)
    {
        //UIManager.Instance.StateName.text = Name;
    }
    public virtual void HandleInput()
    {
        Horizontal = InputHandler.Horzontal;

        Vertical = InputHandler.Vertical;

        //MousePos = InputHandler.MousePosition;
    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicsUpdate()
    {

    }

    public virtual void Exit()
    {

    }


}
