using System.Collections;
using System.Collections.Generic;
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
        };
        StorageManager.SavePlayerSettings(playerSettings);
    }
}
