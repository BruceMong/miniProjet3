using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.Netcode;

public class LaunchGameButton : MonoBehaviour
{
    // Référence au NetworkManager (assurez-vous de l'assigner dans l'éditeur Unity)
    public NetworkManager networkManager;

    // Nom de la scène à charger
    public string GameSceneName;

    private void Start()
    {
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
            SceneManager.LoadScene(GameSceneName, UnityEngine.SceneManagement.LoadSceneMode.Single);
        }
    }
}
