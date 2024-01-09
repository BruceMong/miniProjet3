using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.Netcode;

public class LaunchGameButton : MonoBehaviour
{
    // Référence au NetworkManager (assurez-vous de l'assigner dans l'éditeur Unity)
    public NetworkManager networkManager;
    //Button LaunchGameButton;

    // Nom de la scène à charger
    public string GameSceneName = "Game";

    private void Start()
    {

        // Initialise le NetworkManager s'il n'est pas déjà assigné
        if (networkManager == null)
        {
            networkManager = FindObjectOfType<NetworkManager>(); // Trouve l'instance de NetworkManager dans la scène
        }

        // Exemple : désactive le bouton si ce n'est pas l'host
        if (networkManager != null && !networkManager.IsHost)  // Correction ici
        {
            GetComponent<Button>().interactable = false;
        }

    }

    // Fonction appelée lors du clic sur le bouton
    public void LaunchGame()
    {
        // Assurez-vous que l'application est en mode serveur ou host
        if (networkManager != null && (networkManager.IsServer || networkManager.IsHost))  // Correction ici
        {
            // Chargez la scène de jeu
            NetworkManager.Singleton.SceneManager.LoadScene(GameSceneName, UnityEngine.SceneManagement.LoadSceneMode.Single);
            //Cursor.lockState = CursorLockMode.None;

        }
    }
}