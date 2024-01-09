using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.Netcode;

public class LaunchGameButton : MonoBehaviour
{
    public NetworkManager networkManager;

    private void Start()
    {
        // Initialise le NetworkManager s'il n'est pas déjà assigné
        if (networkManager == null)
        {
            networkManager = FindObjectOfType<NetworkManager>(); // Trouve l'instance de NetworkManager dans la scène
        }

        // Exemple : désactive le bouton si ce n'est pas l'host
        if (!networkManager.IsHost)
        {
            gameObject.SetActive(false);
        }
    }

    // Fonction appelée lors du clic sur le bouton
    public void LaunchGame()
    {
        // Assurez-vous que l'application est en mode serveur ou host
        if ((networkManager.IsServer || networkManager.IsHost))
        {
            // Chargez la scène de jeu
            NetworkManager.Singleton.SceneManager.LoadScene("Game", UnityEngine.SceneManagement.LoadSceneMode.Single);
        }
    }
}
