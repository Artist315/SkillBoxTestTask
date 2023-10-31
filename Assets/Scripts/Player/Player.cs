using UnityEngine;


[RequireComponent(typeof(PlayerMoverView))]
[RequireComponent(typeof(AreasInteraction))]
public class Player : Singleton<Player>
{
    #region Models
    private PlayerFiniteStateMachineModel   playerFiniteStateMachineModel;
    internal AreasInteraction               AreasInteraction;
    [SerializeField]
    internal UpgradeDialogWindow            UpgradeDialogWindow;

    #endregion
    #region Views
    internal PlayerMoverView _playerMoverView;
    #endregion

    #region Player Settings
    public PlayerSettings PlayerSettings { get; private set; }
    #endregion

    private void Awake()
    {
        _playerMoverView = GetComponent<PlayerMoverView>();
        AreasInteraction = GetComponent<AreasInteraction>();
        if (UpgradeDialogWindow == null)
        {
            Debug.LogError("UpgradeDialogWindow not assigned");
        }
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

    public void UpdatePlayerSettings()
    {
        PlayerSettings = StorageManager.ReadPlayerSettings();
    }
}
