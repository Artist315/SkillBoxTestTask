using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ResourcesStorage
{
    public delegate void ResourcesAmountUpdate();
    public static event ResourcesAmountUpdate ResourcesUpdated;
    
    public static ResourcesData Data 
    {
        get
        {
            if (_data == null)
            {
                _data = StorageManager.ReadResourcesData();
            }
            return _data;
        }
        set
        {
            _data = value;
        }
    }
    public static ResourcesData _data;

    public static void SubtractUpgradeResorces(UpgradeRequirements amount)
    {
        Data.Wood   -= amount.WoodAmount;
        Data.Stone  -= amount.StoneAmount;
        Data.Food   -= amount.FoodAmount;
        StorageManager.SaveResources(Data);
        ResourcesUpdated?.Invoke();
    }
    public static void ResetResorces()
    {
        Data.Wood   = 0;
        Data.Stone  = 0;
        Data.Food   = 0;
        StorageManager.SaveResources(Data);
        ResourcesUpdated?.Invoke();
    }

    private static void UpdateUI()
    {

    }

    #region Stone
    internal static void AddStone(int amount)
    {
        if (amount > 0)
        {
            Data.Stone += amount;
            StorageManager.SaveResources(Data);
            ResourcesUpdated?.Invoke();
        }
    }
    #endregion

    #region Food
    internal static void AddFood(int amount)
    {
        if (amount > 0)
        {
            Data.Food += amount;
            StorageManager.SaveResources(Data);
            ResourcesUpdated?.Invoke();
        }
    }
    #endregion

    #region Wood
    public static void AddWood(int amount)
    {
        if (amount > 0)
        {
            Data.Wood += amount;
            StorageManager.SaveResources(Data);
            ResourcesUpdated?.Invoke();
        }
    }
    #endregion
}
