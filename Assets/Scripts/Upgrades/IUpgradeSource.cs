using UnityEngine;

public interface IUpgradeSource
{
    public bool Upgrade();
    public GameObject GetGameObject();

    public string UIText { get; set; }
    public int Level { get; set; }

    public int MaxLevel { get; set; }
}
