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

    [SerializeField]
    //private PlayerSettings _playerSettings;
    //public PlayerCharacteristics Characteristics { get; private set; } = new PlayerCharacteristics();
    #endregion
    // Start is called before the first frame update
    private void Awake()
    {
        _playerMoverView = GetComponent<PlayerMoverView>();
        AreasInteraction = GetComponent<AreasInteraction>();
        //SetCharachteristics();
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
