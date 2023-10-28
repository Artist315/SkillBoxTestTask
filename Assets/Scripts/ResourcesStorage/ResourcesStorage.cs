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
                _data = StorageManager.ReadData();
            }
            return _data;
        }
        set
        {
            _data = value;
        }
    }
    public static ResourcesData _data;

    public static void AddWood(int amount)
    {
        if (amount>0)
        {
            Data.Wood += amount;
            StorageManager.Save(Data);
            ResourcesUpdated?.Invoke();
        }
    }

    private static void UpdateUI()
    {

    }
}
