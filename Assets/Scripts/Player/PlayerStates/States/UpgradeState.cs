using System;
using UnityEngine;

public class UpgradeState : PlayerState
{
    private IUpgradeSource upgradeSource { get; set; }
    public UpgradeState(StateMachine stateMachine) : base(stateMachine)
    {
    }
    public override void Enter(object param = null)
    {
        base.Enter(param);

        if (param is IUpgradeSource upgradeSource)
        {
            this.upgradeSource = upgradeSource;
        }
        else
        {
            throw new Exception("Wrong object");
        }
        Name = "UpgradeState";
        _playerMoverView.SetAnimation("AnimState", 0);
        base.Enter();

        _player.UpgradeDialogWindow.Activate(upgradeSource);
    }

    public override void HandleInput()
    {
        base.HandleInput();

        var gameObject = upgradeSource.GetGameObject();
        var currentDist = Vector3.Distance(gameObject.transform.position, _player.transform.position);
        if (currentDist < Vector3.Distance(gameObject.transform.position, _player.transform.position + new Vector3(Horizontal, 0, Vertical)))
        {
            stateMachine.ChangeState(PlayerStateEnum.Walk);
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void Exit()
    {
        _player.UpgradeDialogWindow.CloseError();
        _player.UpgradeDialogWindow.gameObject.SetActive(false);
        base.Exit();
    }
}
