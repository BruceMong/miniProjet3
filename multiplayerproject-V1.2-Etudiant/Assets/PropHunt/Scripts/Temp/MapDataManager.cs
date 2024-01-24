using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Newtonsoft.Json;
using System.IO;

public class MapDataManager : MonoBehaviour
{
    public void SaveMap(string filePath, MapData mapData)
    {
        string json = JsonUtility.ToJson(mapData);
        File.WriteAllText(filePath, json);
    }

    public MapData LoadMap(string filePath)
    {
        if (!File.Exists(filePath))
            return null;

        string json = File.ReadAllText(filePath);
        return JsonUtility.FromJson<MapData>(json);
    }
}
