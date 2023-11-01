using Palmmedia.ReportGenerator.Core.Common;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Text.Json;
using UnityEngine;

public static class StorageManager
{
    private const string ResourcesDataConnectionString = "ResourcesData.json";
    private const string PlayerSettingsConnectionString = "PlayerSettings.json";

    #region ResourcesData
    public static ResourcesData ReadResourcesData()
    {
        var json = File.Exists(ResourcesDataConnectionString) ? File.ReadAllText(ResourcesDataConnectionString) : string.Empty;

        if (!string.IsNullOrEmpty(json))
        {
            var data = JsonUtility.FromJson<ResourcesData>(json);
            return data;
        }
        return new ResourcesData();
    }
    public static void SaveResources(ResourcesData data)
    {
        var json = JsonUtility.ToJson(data);

        File.WriteAllText(ResourcesDataConnectionString, json);
    }

    #endregion

    #region PlayerSettings
    public static PlayerSettings ReadPlayerSettings()
    {
        var json = File.Exists(PlayerSettingsConnectionString) ? File.ReadAllText(PlayerSettingsConnectionString) : CreatePlayerSettings();

        if (!string.IsNullOrEmpty(json))
        {
            var data = JsonUtility.FromJson<PlayerSettings>(json);
            return data;
        }
        return new PlayerSettings();
    }

    private static string CreatePlayerSettings()
    {
        var settings = new PlayerSettings();
        SavePlayerSettings(settings);
        return JsonUtility.ToJson(settings);
    }

    public static void SavePlayerSettings(PlayerSettings data)
    {
        var json = JsonUtility.ToJson(data);

        File.WriteAllText(PlayerSettingsConnectionString, json);
    }

    #endregion

}

public class ResourcesData
{
    public int Wood = 0;
    public int Stone = 0;
    public int Food = 0;
}

public class PlayerSettings
{
    public float Speed = 3;

    #region Wood
    public int WoodProTick;
    public double WoodRecieveSpeed;
    #endregion

    #region Food
    public int FoodProTick;
    public double FoodRecieveSpeed;
    #endregion
    #region Stone
    public int StoneProTick;
    public double StoneRecieveSpeed;
    #endregion
}