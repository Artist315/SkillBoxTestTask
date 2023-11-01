using UnityEngine;

public class RefreshData : MonoBehaviour
{
    public PlayerSettingsSO PlayerSettingsSO;

    private void Start()
    {
        if (!PlayerSettingsSO)
        {
            Debug.LogWarning("PlayerSettingsSO is not assigned");
        }
    }
    public void OnClick()
    {
        ResourcesStorage.ResetResorces();

        var playerSettings = new PlayerSettings()
        {
            Speed = PlayerSettingsSO.Speed,

            WoodProTick = PlayerSettingsSO.WoodProTick,
            WoodRecieveSpeed = PlayerSettingsSO.WoodRecieveSpeed,

            FoodProTick = PlayerSettingsSO.FoodProTick,
            FoodRecieveSpeed = PlayerSettingsSO.FoodRecieveSpeed,

            StoneProTick = PlayerSettingsSO.StoneProTick,
            StoneRecieveSpeed = PlayerSettingsSO.StoneRecieveSpeed,


        };
        StorageManager.SavePlayerSettings(playerSettings);
        Player.Instance.UpdatePlayerSettings();
    }
}
