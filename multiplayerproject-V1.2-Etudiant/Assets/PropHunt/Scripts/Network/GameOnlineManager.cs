using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections;
using Unity.Netcode;
using UnityEngine;

public class GameOnlineManager : NetworkBehaviour
{
    private float huntStartTime = 10.0f; // Durée du décompte en secondes
    private NetworkVariable<float> timeUntilHuntStarts = new NetworkVariable<float>();
    PlayerManager playerManagerClient = null;
    public Canvas blackScreenHunter;

    public TextMeshProUGUI lifeText; // Assurez-vous d'avoir using UnityEngine.UI;
    public TextMeshProUGUI score; // Assurez-vous d'avoir using UnityEngine.UI;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        blackScreenHunter.enabled = false;
    }

    public TextMeshProUGUI GetLifeText()
    {
       return lifeText; 
    }
    public TextMeshProUGUI GetScore()
    {
         return score; 
    }

    public override void OnNetworkSpawn() //OnNetworkSpawn
    {
        //playerManagerClient = NetworkManager.Singleton.LocalClient.PlayerObject.GetComponent<PlayerManager>();


    }

    public void setPlayerManagerLocal(PlayerManager playermanager)
    {
        if(playerManagerClient == null) playerManagerClient = playermanager;


    }
    public void GameStart()
    {
        if (playerManagerClient.IsHunter)
        {
            blackScreenHunter.enabled = true;


            playerManagerClient.EnableInputState(false);
        }

        if (IsServer)
        {
            StartCoroutine(StartHuntTimer());
        }
    }


    private IEnumerator StartHuntTimer()
    {
        float remainingTime = huntStartTime;
        while (remainingTime > 0)
        {
            timeUntilHuntStarts.Value = remainingTime;
            yield return new WaitForSeconds(1f);
            remainingTime--;
            Debug.Log(remainingTime);

        }

        ServerStartHuntServerRpc();
    }

    [ServerRpc]
    private void ServerStartHuntServerRpc()
    {
        // Ici, envoyez un message aux Hunters pour activer leur mouvement et vision
        StartHuntClientRpc();
        Debug.Log("Vision active");

    }

    [ClientRpc]
    private void StartHuntClientRpc()
    {
        if (playerManagerClient.IsHunter)
        {
            blackScreenHunter.enabled = false;
            playerManagerClient.EnableInputState(true);

        }
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
        bool isAnyHunterAlive = false;
        bool isAnyPropAlive = false;

        List<PlayerManager> allPlayerManagers = GetAllPlayerManagers();

        foreach (PlayerManager player in allPlayerManagers)
        {
            if (player.Life > 0) // Si le joueur est en vie
            {
                if (player.IsHunter)
                {
                    isAnyHunterAlive = true;
                }
                else
                {
                    isAnyPropAlive = true;
                }
            }
        }

        // Vérifiez les conditions de fin de jeu
        if (!isAnyHunterAlive)
        {
            Debug.Log("GameOver - Prop Team Wins!");
        }
        else if (!isAnyPropAlive)
        {
            Debug.Log("GameOver - Hunter Team Wins!");
        }
    }


}
