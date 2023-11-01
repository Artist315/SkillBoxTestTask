using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

namespace Assets.Scripts.Player.PlayerStates.States
{
    public class ChopState : PlayerState
    {
        private Tree Tree { get; set; }
        private Coroutine coroutine;
        public ChopState(StateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter(object param = null)
        {
            if (param is Tree tree)
            {
                Tree = tree;
            }
            Name = "ChopState";
            _playerMoverView.SetAnimation("AnimState", 2);
            Debug.Log("LookAtTree");
            _playerMoverView.LookAt(Tree.transform);
            coroutine = TimerManager.Instance.CreateRepeatedTimer(_player.PlayerSettings.WoodRecieveSpeed, GetWood);

            base.Enter();
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
            if (Tree.ResourceAmount - _player.PlayerSettings.StoneProTick > 0)
            {
                Debug.Log("RecieveWood");
                Tree.ResourceAmount -= _player.PlayerSettings.WoodProTick;
                ResourcesStorage.AddWood(_player.PlayerSettings.WoodProTick);
            }
        }

        public override void Exit()
        {
            TimerManager.Instance.StopTimer(coroutine);
            base.Exit();
        }
    }
}
