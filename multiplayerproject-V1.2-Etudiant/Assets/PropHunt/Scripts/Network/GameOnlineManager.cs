using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.Collections;
using Unity.Netcode;
using UnityEngine;

public class GameOnlineManager : NetworkBehaviour
{

    private List<PlayerManager> playerManagers = new List<PlayerManager>();

    private float gameStartTime = 10.0f; // Durée du décompte en secondes
    private NetworkVariable<float> timeUntilGameStarts = new NetworkVariable<float>();
    PlayerManager playerManagerClient = null;
    //private static int playerSpawnIndex = 0;
    
    private NetworkVariable<bool> _gameStart = new NetworkVariable<bool>(false);

    GameObject spawnPosPlayers;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }



    public override void OnNetworkSpawn() //OnNetworkSpawn
    {
        //playerManagerClient = NetworkManager.Singleton.LocalClient.PlayerObject.GetComponent<PlayerManager>();
        if (IsServer)
        {
            NetworkManager.Singleton.OnClientConnectedCallback += OnClientConnected;
            NetworkManager.Singleton.OnClientDisconnectCallback += OnClientDisconnected;
            _gameStart.OnValueChanged += TpPlayerStart;
        }

    }
    public bool IsGameStart
    {
        get { return _gameStart.Value; }

    }


    private void OnClientConnected(ulong clientId)
    {
        var playerManager = NetworkManager.Singleton.ConnectedClients[clientId].PlayerObject.GetComponent<PlayerManager>();
        if (playerManager != null)
        {
            playerManagers.Add(playerManager);
        }
    }

    private void OnClientDisconnected(ulong clientId)
    {
        var playerManager = playerManagers.FirstOrDefault(p => p.OwnerClientId == clientId);
        if (playerManager != null)
        {
            playerManagers.Remove(playerManager);
        }
    }





    private void TpPlayerStart(bool oldValue, bool newValue)
    {

        if (newValue && spawnPosPlayers != null)
        {
            // Assurez-vous que la liste est triée
            Debug.Log("tp");
            Debug.Log(spawnPosPlayers);
            Debug.Log(playerManagers);
            Debug.Log(playerManagers.IndexOf(playerManagerClient));


            SortPlayerManagers();            
            var spawnPosition = spawnPosPlayers.transform.GetChild(playerManagers.IndexOf(playerManagerClient)).position;

            playerManagerClient.TeleportToPos(spawnPosition);
            playerManagerClient.SetSpawn(spawnPosition);
        }
    }



    public void setPlayerManagerLocal(PlayerManager playermanager)
    {
        if(playerManagerClient == null) playerManagerClient = playermanager;


    }

    public void GameStart()
    {
        spawnPosPlayers = GameObject.FindGameObjectWithTag("SpawnPlatform");

        if (IsServer)
        {
            Debug.Log("game start");
            _gameStart.Value = true;
            StartCoroutine(StartGameTimer());
        }
    }

    private IEnumerator StartGameTimer()
    {
        float remainingTime = gameStartTime;
        while (remainingTime > 0)
        {
            UpdateCountdownClientRpc(remainingTime); // Mettre à jour le décompte sur les clients
            yield return new WaitForSeconds(1f);
            remainingTime--;
            //Debug.Log(remainingTime);
        }

        StartGameClientRpc(); // Commencer le jeu sur les clients
    }

    [ClientRpc]
    private void UpdateCountdownClientRpc(float countdownValue)
    {
        
        playerManagerClient.UpdateCompteurUI("La partie commence dans : \n" + countdownValue);
    }

    [ClientRpc]
    private void StartGameClientRpc()
    {
        // Réactiver le contrôle du joueur
        // Par exemple, permettre aux joueurs de se déplacer
        playerManagerClient.UpdateCompteurUI("");
        Debug.Log("Le jeu commence !");
    }

    List<PlayerManager> GetAllPlayerManagers()
    {
        List<PlayerManager> allPlayerManagers = new List<PlayerManager>();

        foreach (var client in NetworkManager.Singleton.ConnectedClients)
        {
            PlayerManager playerManager = client.Value.PlayerObject.GetComponent<PlayerManager>();
            if (playerManager != null)
            {
                allPlayerManagers.Add(playerManager);
            }
        }

        return allPlayerManagers;
    }


    public void CheckForGameOver()
    {
    }

    private void SortPlayerManagers()
    {
        playerManagers = playerManagers.OrderBy(pm => pm.OwnerClientId).ToList();
    }
}
