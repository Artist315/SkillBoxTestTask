using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class UpgradeSource : MonoBehaviour, IUpgradeSource
{
    [SerializeField]
    public List<UpgradeRequirements> UpgradeRequirements = new List<UpgradeRequirements>() { new UpgradeRequirements()};

    [SerializeField]
    public List<float> UpgradeResult = new List<float>();

    public int Level { get; set; } = 1;

    public int MaxLevel { get; set; } = 1;
    public string UIText { get; set; }

    public virtual void Start()
    {
        MaxLevel = Mathf.Min(UpgradeRequirements.Count, UpgradeResult.Count);
    }
    public virtual bool Upgrade()
    {
        if (!CkeckNextLEvelExists())
        {
            Debug.Log("CkeckNextLEvelExists failed");
            return false;
        }
        if (!UpgradeCheck())
        {
            Player.Instance.UpgradeDialogWindow.OnError("Недостоточно ресурсов");

            return false;
        }

        ResourcesStorage.SubtractUpgradeResorces(UpgradeRequirements[Level]);
        Level++;
        ApplyUpgrade();
        return true;

    }

    private bool UpgradeCheck()
    {
        return
            ResourcesStorage.Data.Wood      >= UpgradeRequirements[Level].WoodAmount
            && ResourcesStorage.Data.Stone  >= UpgradeRequirements[Level].StoneAmount
            && ResourcesStorage.Data.Food   >= UpgradeRequirements[Level].FoodAmount;
    }
    private bool CkeckNextLEvelExists()
    {
        return UpgradeRequirements.ElementAtOrDefault(Level) != null;
    }

    public abstract void ApplyUpgrade();

    public GameObject GetGameObject()
    {
        return gameObject;
    }
}
