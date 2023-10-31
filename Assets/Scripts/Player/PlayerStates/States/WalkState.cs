using System;
using UnityEngine;

namespace Assets.Scripts.Player.PlayerStates.States
{
    public class WalkState : PlayerState
    {
        public WalkState(StateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter(object param = null)
        {
            Name = "WalkState";
            _playerMoverView.SetAnimation("AnimState", 1);
            _player.AreasInteraction.TreeInTheArea += StartCuttingTree;
            _player.AreasInteraction.RockInTheArea += StartMining;
            _player.AreasInteraction.FoodInTheArea += StartGathering;
            base.Enter();
        }

        private void StartMining(object obj)
        {
            stateMachine.ChangeState(PlayerStateEnum.Mine, obj);
        }
        private void StartGathering(object obj)
        {
            stateMachine.ChangeState(PlayerStateEnum.Gather, obj);
        }

        private void StartCuttingTree(object obj)
        {
            stateMachine.ChangeState(PlayerStateEnum.Chop, obj);
        }

        public override void HandleInput()
        {
            base.HandleInput();


            if (Horizontal == 0 && Vertical == 0)
            {
                stateMachine.ChangeState(PlayerStateEnum.Idle);
            }

        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            var dir = Horizontal + Vertical;
            var currentDir = _player.transform.position + new Vector3(Horizontal, 0, Vertical);
            _playerMoverView.LookAt(currentDir);

            _playerMoverView.Move(Vector3.Normalize(new Vector3(Horizontal,0 , Vertical)) * Time.deltaTime * _player.PlayerSettings.Speed);
        }

        public override void Exit()
        {
            _player.AreasInteraction.TreeInTheArea -= StartCuttingTree;
            _player.AreasInteraction.RockInTheArea -= StartMining;
            _player.AreasInteraction.RockInTheArea -= StartGathering;
            base.Exit();
        }
    }
}
