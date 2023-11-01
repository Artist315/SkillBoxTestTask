
using UnityEngine;
[CreateAssetMenu(fileName = "PlayerSettings", menuName = "ScriptableObjects/PlayerSettings", order = 1)]

public class PlayerSettingsSO : ScriptableObject
{
    public float Speed = 3;

    #region Wood
    public int WoodProTick = 3;
    public float WoodRecieveSpeed = 0.5f;
    #endregion

    #region Food
    public int FoodProTick = 3;
    public float FoodRecieveSpeed = 0.5f;
    #endregion
    #region Stone
    public int StoneProTick = 3;
    public float StoneRecieveSpeed = 0.5f;
    #endregion
}
