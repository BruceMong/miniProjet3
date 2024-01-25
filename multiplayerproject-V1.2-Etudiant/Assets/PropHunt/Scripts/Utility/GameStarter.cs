
using UnityEngine;

using Unity.Netcode;



public class GameStarter : NetworkBehaviour
{
    public GameOnlineManager gameOnlineManager;

    // Start is called before the first frame update
    void Start()
    {
        if (gameOnlineManager == null && IsServer)
        {
            gameOnlineManager = FindObjectOfType<GameOnlineManager>();
            gameOnlineManager.GameStart();
            MapManager.Instance.LoadMap();

            Debug.Log("gameStarter");

        }
    }

}
