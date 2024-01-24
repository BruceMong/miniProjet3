using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.Netcode;
using UnityEngine;

public class MapManager : NetworkBehaviour
{
    // Start is called before the first frame update

    string path = null;

    public List<Transform> SpawnPoints;
    public string _mapSelected = null;

    private TextMeshProUGUI _textmapSelected;


    public override void OnNetworkSpawn()

    {
        Debug.Log(IsServer);
        if (NetworkManager.Singleton == null || !NetworkManager.Singleton.IsServer)
            return;

        path = Application.streamingAssetsPath + "/";
        //_textmapSelected = GameObject.FindWithTag("MapSelect").GetComponent<TextMeshProUGUI>();
        //Debug.Log("sperme");
        //Debug.Log(_textmapSelected);
        //for (int i = 0; i < nPropsToSpawn; i++)
        //{
        //    var sp = SpawnPoints[i];
        //    var transform = PropToSpawn.transform;
        //    var go = Instantiate(PropToSpawn.gameObject, sp.position, transform.rotation);
        //    go.GetComponent<NetworkObject>().Spawn();
        //}
    }

    public void SetMapSelected(string mapSelected)
    {
        Debug.Log(_textmapSelected);
        //_textmapSelected.text = mapSelected;
        _mapSelected = mapSelected;

    }
    // Cette fonction retourne un tableau de chaînes contenant les noms de tous les fichiers dans le dossier spécifié
    public string[] GetFileNamesInDirectory()
    {

        string directoryPath = Application.streamingAssetsPath;
        try
        {
            // Assurez-vous que le chemin spécifié existe
            if (Directory.Exists(directoryPath))
            {
                // Récupère tous les fichiers dans le dossier
                string[] filePaths = Directory.GetFiles(directoryPath);

                // Pour stocker uniquement les noms de fichiers
                string[] fileNames = new string[filePaths.Length];

                for (int i = 0; i < filePaths.Length; i++)
                {
                    // Obtient le nom de fichier sans le chemin complet
                    fileNames[i] = Path.GetFileName(filePaths[i]);
                }

                return fileNames;
            }
            else
            {
                Debug.LogWarning("Directory does not exist: " + directoryPath);
                return new string[0];
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogError("An error occurred: " + ex.Message);
            return new string[0];
        }
    }


public void loadMap(string mapName)
    {

    }


// Update is called once per frame
void Update()
    {
        
    }
}
