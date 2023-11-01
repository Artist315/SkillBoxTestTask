using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class GatherState : PlayerState
{
    private Food Food { get; set; }
    private Coroutine coroutine;
    public GatherState(StateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter(object param = null)
    {
        base.Enter(param);

        if (param is Food food)
        {
            Food = food;
        }
        else
        {
            throw new Exception("Wrong object");
        }
        Name = "ChopState";
        _playerMoverView.SetAnimation("AnimState", 3);
        base.Enter();
        Debug.Log("LookAtTree");
        _playerMoverView.LookAt(Food.transform);
        coroutine = TimerManager.Instance.CreateRepeatedTimer(_player.PlayerSettings.FoodRecieveSpeed, GetFood);
    }
    public override void HandleInput()
    {
        base.HandleInput();

        var dir = Horizontal + Vertical;
        var currentDist = Vector3.Distance(Food.transform.position, _player.transform.position);
        if (currentDist < Vector3.Distance(Food.transform.position, _player.transform.position + new Vector3(Horizontal, 0, Vertical)))
        {
            stateMachine.ChangeState(PlayerStateEnum.Walk);
        }
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    private void GetFood()
    {
        if (Food.ResourceAmount - _player.PlayerSettings.FoodProTick > 0)
        {
            Debug.Log("RecieveFood");
            Food.ResourceAmount -= _player.PlayerSettings.FoodProTick;
            ResourcesStorage.AddFood(_player.PlayerSettings.FoodProTick);
        }
        else if (Food.ResourceAmount > 0)
        {
            Debug.Log("RecieveResttones");
            ResourcesStorage.AddWood(Food.ResourceAmount);
            Food.ResourceAmount = 0;
            stateMachine.ChangeState(PlayerStateEnum.Idle);

        }
    }

    public override void Exit()
    {
        TimerManager.Instance.StopTimer(coroutine);
        base.Exit();
    }
}
