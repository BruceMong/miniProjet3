using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Newtonsoft.Json;
using System.IO;

public class MapDataManager : MonoBehaviour
{

    public static MapDataManager Instance;

    public MapData CurrentMapData { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void SaveMap(string filePath)
    {
        CurrentMapData = new MapData();

        // Collecter les données de chaque objet à sauvegarder
        foreach (var prefab in FindObjectsOfType<GameObject>())
        {
            if (prefab.CompareTag("Saveable"))
            {
                Vector3? finalPosition = null;

                // Vérifiez si c'est une plateforme mouvante et obtenez la position finale
                if (prefab.CompareTag("MovablePlatform"))
                {
                    //var movablePlatform = prefab.GetComponent<MovablePlatformScript>(); // Obtenez votre script personnalisé
                    //finalPosition = movablePlatform.FinalPosition; // Obtenez la position finale
                }

                var mapObject = new MapObject(
                    prefab.name,
                    prefab.transform.position,
                    prefab.transform.rotation,
                    prefab.transform.localScale,
                    finalPosition);

                CurrentMapData.AddObject(mapObject);
            }
        }

        // Sérialiser et sauvegarder
        string json = JsonUtility.ToJson(CurrentMapData);
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
