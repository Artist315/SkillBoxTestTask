using Palmmedia.ReportGenerator.Core.Common;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Text.Json;
using UnityEngine;

public static class StorageManager
{
    private const string connectionString = "ResourcesData";

    public static ResourcesData ReadData()
    {
        var json = File.Exists(connectionString) ? File.ReadAllText(connectionString) : string.Empty;

        if (!string.IsNullOrEmpty(json))
        {
            var data = JsonUtility.FromJson<ResourcesData>(json);
            return data;
        }
        //File.Create(connectionString);
        return new ResourcesData();
    }

    public static void Save(ResourcesData data)
    {
        var json = JsonUtility.ToJson(data);

        File.WriteAllText(connectionString, json);
    }

}

public class ResourcesData
{
    public int Wood = 0;
}