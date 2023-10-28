using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Player.PlayerStates.States
{
    public class ChopState : PlayerState
    {
        private GameObject Tree { get; set; }
        private Coroutine coroutine;
        public ChopState(StateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter(object param = null)
        {
            if (param is GameObject tree)
            {
                Tree = tree;
            }
            Name = "ChopState";
            _playerMoverView.SetAnimation("AnimState", 2);
            base.Enter();
            Debug.Log("LookAtTree");
            _playerMoverView.LookAt(Tree.transform);
            coroutine = TimerManager.Instance.CreateRepeatedTimer(.5f, GetWood);
        }
        public override void HandleInput()
        {
            base.HandleInput();

            var dir = Horizontal + Vertical;
            var currentDist = Vector3.Distance(Tree.transform.position , _player.transform.position);
            if (currentDist < Vector3.Distance(Tree.transform.position, _player.transform.position + new Vector3(Horizontal, 0, Vertical)))
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
            if (Tree.TryGetComponent<Tree>(out var tree))
            {
                if (tree.WoodAmount - tree.WoodProTick > 0)
                {
                    Debug.Log("RecieveWood");
                    tree.WoodAmount -= tree.WoodProTick;
                    ResourcesStorage.AddWood(tree.WoodProTick);
                }
                
            }
        }

        public override void Exit()
        {
            TimerManager.Instance.StopTimer(coroutine);
            base.Exit();
        }
    }
}
