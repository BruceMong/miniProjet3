


using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class MapSelect : MonoBehaviour

{
    public GameObject togglePrefab; // R�f�rence � votre prefab Toggle
    public Transform scrollViewContent; // R�f�rence au contenu de votre ScrollView
    public MapManager mapManager;

    void Start()
    {
        string[] fileNames = mapManager.GetFileNamesInDirectory();
        foreach (string fileName in fileNames)
        {
            CreateToggleForFile(fileName);
        }
    }

    void CreateToggleForFile(string fileName)
    {
        GameObject toggleObj = Instantiate(togglePrefab, scrollViewContent);
        toggleObj.GetComponentInChildren<Text>().text = fileName;
        Toggle toggle = toggleObj.GetComponent<Toggle>();

        // Ajoutez un �couteur pour le Toggle si n�cessaire
        toggle.onValueChanged.AddListener(delegate { OnToggleChanged(toggle, fileName); });
    }

    void OnToggleChanged(Toggle toggle, string fileName)
    {
        if (toggle.isOn)
        {
            Debug.Log("Selected map: " + fileName);
            // Traitez la s�lection ici
        }
    }
}
