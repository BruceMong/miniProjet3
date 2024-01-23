using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMenuClose : MonoBehaviour
{
    public GameObject panelMainMenu;
    private HandMenuManager handMenuManager;

    // Ajoutez une liste d'objets � d�sactiver lors de la fermeture du menu
    public List<GameObject> objectsToDisable;

    void Start()
    {
        handMenuManager = FindObjectOfType<HandMenuManager>();

        if (handMenuManager == null)
        {
            Debug.LogError("HandMenuManager non trouv�.");
        }
    }

    public void FirstButtonClicked()
    {
        // D�sactiver le menu principal
        panelMainMenu.SetActive(false);
    }

    public void OpenMainMenu()
    {
        // Activer � nouveau le menu principal
        panelMainMenu.SetActive(true);
    }

    public void CloseMenu()
    {
        // D�sactiver les objets sp�cifi�s lors de la fermeture du menu
        foreach (GameObject go in objectsToDisable)
        {
            go.SetActive(false);
        }
    }
}
