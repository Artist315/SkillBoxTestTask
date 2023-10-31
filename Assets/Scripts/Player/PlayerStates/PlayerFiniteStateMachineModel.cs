using Assets.Scripts.Player.PlayerStates.States;

public class PlayerFiniteStateMachineModel
{
    private StateMachine _stateMachine { get; set; }


    public WalkState Walk { private set; get; }
    public ChopState Chop { private set; get; }
    public MineState Mine { private set; get; }
    public IdleState Idle { private set; get; }
    public GatherState Gather { private set; get; }
    public UpgradeState Upgrade { private set; get; }

    public PlayerFiniteStateMachineModel()
    {
        _stateMachine = new StateMachine(this);

        Walk    = new WalkState(_stateMachine);
        Chop    = new ChopState(_stateMachine);
        Mine    = new MineState(_stateMachine);
        Idle    = new IdleState(_stateMachine);
        Gather  = new GatherState(_stateMachine);
        Upgrade = new UpgradeState(_stateMachine);

        _stateMachine.Initialize(Idle);
    }
    public void Update()
    {
        _stateMachine.CurrentState.HandleInput();

        _stateMachine.CurrentState.LogicUpdate();
    }

    public void FixedUpdate()
    {
        _stateMachine.CurrentState.PhysicsUpdate();
    }
}

