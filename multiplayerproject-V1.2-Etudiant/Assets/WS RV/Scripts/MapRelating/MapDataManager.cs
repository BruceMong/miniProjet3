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
    public void SaveMap()
    {

        string basePath = Application.streamingAssetsPath;
        string baseFileName = "mapData";
        string fileExtension = ".json";
        int counter = 0;

        string fileName = baseFileName + fileExtension;
        string filePath = Path.Combine(basePath, fileName);
        //Debug.Log(fileName);
        //Debug.Log(filePath);

        // Trouver un nom de fichier non utilis�
        while (File.Exists(filePath))
        {
            counter++;
            fileName = baseFileName + counter.ToString() + fileExtension;
            filePath = Path.Combine(basePath, fileName);
        }
        CurrentMapData = new MapData();

        // Collecter les donn�es de chaque objet � sauvegarder
        foreach (var prefab in FindObjectsOfType<GameObject>())
        {
            if (prefab.CompareTag("Saveable"))
            {
                Vector3? finalPosition = null;
                float? speed = null;

                // V�rifiez si c'est une plateforme mouvante et obtenez la position finale
                Debug.Log(prefab.name);


                var movablePlatform = prefab.GetComponent<MovePlateformValueSlider>();
                Debug.Log(movablePlatform);

                if (movablePlatform)
                {


                    finalPosition = movablePlatform.posToMove; // Obtenez la position finale
                    speed = movablePlatform.speed;
                }

                var mapObject = new MapObject(
                    prefab.name,
                    prefab.transform.position,
                    prefab.transform.rotation,
                    prefab.transform.localScale,
                    finalPosition,
                    speed );

                CurrentMapData.AddObject(mapObject);
            }
        }

        // S�rialiser et sauvegarder
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
