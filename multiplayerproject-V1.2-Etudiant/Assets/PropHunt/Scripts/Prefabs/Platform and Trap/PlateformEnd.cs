using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlateformEnd : MonoBehaviour
{

    GameOnlineManager _gameOnlineManager;
    bool finish = false;
    void Start()
    {
            _gameOnlineManager = FindObjectOfType<GameOnlineManager>();
    }

    void OnTriggerEnter(Collider collision)
    {
        if (_gameOnlineManager.IsGameStart == false || finish) return;

        PlayerManager playerColManager = collision.gameObject.transform.root.gameObject.GetComponent<PlayerManager>();


        if (NetworkManager.Singleton.LocalClient.PlayerObject.GetComponent<PlayerManager>() == playerColManager)
        {
            Debug.Log("checkpoint valided");
            // Modifier la position de spawn avec Y augmenté de 3 unités
            Vector3 spawnPosition = gameObject.transform.position + new Vector3(0, 3, 0);
            playerColManager.SetSpawn(spawnPosition);



        }

    }
}
