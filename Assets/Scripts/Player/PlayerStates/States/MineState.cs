using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class MineState : PlayerState
{
    private Rock Rock { get; set; }
    private Coroutine coroutine;
    public MineState(StateMachine stateMachine) : base(stateMachine)
    {
        
    }

    public override void Enter(object param = null)
    {
        base.Enter(param);

        if (param is Rock rock)
        {
            Rock = rock;
        }
        else
        {
            throw new Exception("Wrong object");
        }
        Name = "ChopState";
        _playerMoverView.SetAnimation("AnimState", 4);
        base.Enter();
        Debug.Log("LookAtTree");
        _playerMoverView.LookAt(Rock.transform);
        coroutine = TimerManager.Instance.CreateRepeatedTimer(_player.PlayerSettings.StoneRecieveSpeed, GetWood);
    }
    public override void HandleInput()
    {
        base.HandleInput();

        var dir = Horizontal + Vertical;
        var currentDist = Vector3.Distance(Rock.transform.position, _player.transform.position);
        if (currentDist < Vector3.Distance(Rock.transform.position, _player.transform.position + new Vector3(Horizontal, 0, Vertical)))
        {
            stateMachine.ChangeState(PlayerStateEnum.Walk);
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    private void GetWood()
    {
        if (Rock.ResourceAmount - _player.PlayerSettings.StoneProTick > 0)
        {
            Debug.Log("RecieveStones");
            Rock.ResourceAmount -= _player.PlayerSettings.StoneProTick;
            ResourcesStorage.AddStone(_player.PlayerSettings.StoneProTick);
        }
        else if (Rock.ResourceAmount > 0)
        {
            Debug.Log("RecieveResttones");
            ResourcesStorage.AddWood(Rock.ResourceAmount);
            Rock.ResourceAmount = 0;
            stateMachine.ChangeState(PlayerStateEnum.Idle);

        }
    }

    public override void Exit()
    {
        TimerManager.Instance.StopTimer(coroutine);
        base.Exit();
    }
}
