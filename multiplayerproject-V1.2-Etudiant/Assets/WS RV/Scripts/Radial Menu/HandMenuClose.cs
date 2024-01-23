using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMenuClose : MonoBehaviour
{
    public GameObject panelMainMenu;
    private HandMenuManager handMenuManager;

    // Ajoutez une liste d'objets à désactiver lors de la fermeture du menu
    public List<GameObject> objectsToDisable;

    void Start()
    {
        handMenuManager = FindObjectOfType<HandMenuManager>();

        if (handMenuManager == null)
        {
            Debug.LogError("HandMenuManager non trouvé.");
        }
    }

    public void FirstButtonClicked()
    {
        // Désactiver le menu principal
        panelMainMenu.SetActive(false);
    }

    public void OpenMainMenu()
    {
        // Activer à nouveau le menu principal
        panelMainMenu.SetActive(true);
    }

    public void CloseMenu()
    {
        // Désactiver les objets spécifiés lors de la fermeture du menu
        foreach (GameObject go in objectsToDisable)
        {
            go.SetActive(false);
        }
    }
}
