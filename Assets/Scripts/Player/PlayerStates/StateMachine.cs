using UnityEngine;

public class StateMachine
{
    public PlayerState CurrentState;
    private readonly PlayerFiniteStateMachineModel _playerFiniteStateMachineModel;

    public StateMachine(PlayerFiniteStateMachineModel playerFiniteStateMachineModel)
    {
        _playerFiniteStateMachineModel = playerFiniteStateMachineModel;
    }
    public void Initialize(PlayerState startingState)
    {
        CurrentState = startingState;
        startingState.Enter();
    }

    public void ChangeState(PlayerStateEnum state, object param = null)
    {
        CurrentState.Exit();

        switch (state)
        {
            case PlayerStateEnum.Walk:
                CurrentState = _playerFiniteStateMachineModel.Walk;
                break;
            case PlayerStateEnum.Idle:
                CurrentState = _playerFiniteStateMachineModel.Idle;
                break;
            case PlayerStateEnum.Chop:
                CurrentState = _playerFiniteStateMachineModel.Chop;
                break;
            case PlayerStateEnum.Mine:
                CurrentState = _playerFiniteStateMachineModel.Mine;
                break;
            case PlayerStateEnum.Gather:
                CurrentState = _playerFiniteStateMachineModel.Gather;
                break;
            //case PlayerStateEnum.Detecting:
            //    CurrentState = _playerFiniteStateMachineModel.Detecting;
            //    break;
            //case PlayerStateEnum.Default:
            //    break;
            default:
                Debug.LogWarning("WrongState");
                break;
        }        
        CurrentState.Enter(param);
    }
}

