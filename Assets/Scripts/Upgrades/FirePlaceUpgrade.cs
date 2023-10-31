using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FirePlaceUpgrade : UpgradeSource
{
    private List<float> ChangedSpeed = new List<float>();



    public override void Start()
    {
        base.Start();
        ChangedSpeed = UpgradeResult.Cast<float>().ToList();
        UIText = $"Для улучшения нужно:{UpgradeRequirements[Level - 1].WoodAmount} дерева\r\n\r\nИзменение:\r\nПерсонаж получит +{ChangedSpeed[Level]} к скорости";
    }

    public override bool Upgrade()
    {
        return base.Upgrade();
    }
    public override void ApplyUpgrade()
    {

        UIText = $"Для улучшения нужно:{UpgradeRequirements[Level - 1].WoodAmount} дерева\r\n\r\nИзменение:\r\nПерсонаж получит +{ChangedSpeed[Level]} к скорости";
        var playerSettings = StorageManager.ReadPlayerSettings();
        playerSettings.Speed += ChangedSpeed[Level];

        StorageManager.SavePlayerSettings(playerSettings);
        Player.Instance.UpdatePlayerSettings();
    }
}