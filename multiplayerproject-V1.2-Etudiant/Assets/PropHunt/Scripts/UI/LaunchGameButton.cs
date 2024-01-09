using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.Netcode;

public class LaunchGameButton : MonoBehaviour
{
    // R�f�rence au NetworkManager (assurez-vous de l'assigner dans l'�diteur Unity)
    public NetworkManager networkManager;
    //Button LaunchGameButton;

    // Nom de la sc�ne � charger
    public string GameSceneName = "Game";

    private void Start()
    {

        // Initialise le NetworkManager s'il n'est pas d�j� assign�
        if (networkManager == null)
        {
            networkManager = FindObjectOfType<NetworkManager>(); // Trouve l'instance de NetworkManager dans la sc�ne
        }

        // Exemple : d�sactive le bouton si ce n'est pas l'host
        if (networkManager != null && !networkManager.IsHost)  // Correction ici
        {
            GetComponent<Button>().interactable = false;
        }

    }

    // Fonction appel�e lors du clic sur le bouton
    public void LaunchGame()
    {
        // Assurez-vous que l'application est en mode serveur ou host
        if (networkManager != null && (networkManager.IsServer || networkManager.IsHost))  // Correction ici
        {
            // Chargez la sc�ne de jeu
            NetworkManager.Singleton.SceneManager.LoadScene(GameSceneName, UnityEngine.SceneManagement.LoadSceneMode.Single);
            //Cursor.lockState = CursorLockMode.None;

        }
    }
}