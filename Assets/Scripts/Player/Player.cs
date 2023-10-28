using UnityEngine;


[RequireComponent(typeof(PlayerMoverView))]
[RequireComponent(typeof(AreasInteraction))]
public class Player : Singleton<Player>
{
    #region Models
    private PlayerFiniteStateMachineModel   playerFiniteStateMachineModel;
    internal AreasInteraction                AreasInteraction;

    #endregion
    #region Views
    internal PlayerMoverView _playerMoverView;
    #endregion

    #region Player Settings
    public PlayerSettings PlayerSettings { get; private set; }
    #endregion
    // Start is called before the first frame update
    private void Awake()
    {
        _playerMoverView = GetComponent<PlayerMoverView>();
        AreasInteraction = GetComponent<AreasInteraction>();
        PlayerSettings = StorageManager.ReadPlayerSettings();
    }

    private void Start()
    {
        playerFiniteStateMachineModel = new PlayerFiniteStateMachineModel();
    }
    private void Update()
    {
        playerFiniteStateMachineModel.Update();
    }

    private void FixedUpdate()
    {
        playerFiniteStateMachineModel.FixedUpdate();
    }
}
