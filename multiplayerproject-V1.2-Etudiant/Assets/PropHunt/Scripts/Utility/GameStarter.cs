using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStarter : MonoBehaviour
{
    public GameOnlineManager gameOnlineManager;

    // Start is called before the first frame update
    void Start()
    {
        if (gameOnlineManager == null)
        {
            gameOnlineManager = FindObjectOfType<GameOnlineManager>();
            gameOnlineManager.GameStart();
            Debug.Log("gameStarter");

        }
    }

}
