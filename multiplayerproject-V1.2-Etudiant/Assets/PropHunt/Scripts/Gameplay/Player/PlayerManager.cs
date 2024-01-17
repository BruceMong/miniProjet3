using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using Unity.Netcode;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

public class PlayerManager : NetworkBehaviour
{
    protected MovementController _movementController;
    public Camera Camera;
    protected ClassController _currentController;

    // Utilisation de NetworkVariable pour synchroniser l'état isHunter
    private NetworkVariable<bool> _isHunterNetwork = new NetworkVariable<bool>();
    private NetworkVariable<int> _life = new NetworkVariable<int>(5);
    public TextMeshProUGUI lifeText; // Assurez-vous d'avoir using UnityEngine.UI;
    public TextMeshProUGUI score; // Assurez-vous d'avoir using UnityEngine.UI;
    public TextMeshProUGUI _compteur; // Assurez-vous d'avoir using UnityEngine.UI;


    public ActionInput _actionInput;
    public Animator _animator;
    [SerializeField] PropController _propController;
    [SerializeField] HunterController _hunterController;
    GameOnlineManager _gameOnlineManager;
    UnityEngine.Vector3 _spawnPoint = new UnityEngine.Vector3(0,0,0);

    private void Awake()
    {
        _gameOnlineManager = FindObjectOfType<GameOnlineManager>(); 
        _movementController = GetComponent<MovementController>();
        if (_propController == null)
        {
            _propController = GetComponentInChildren<PropController>();
        }
        if (_hunterController == null)
        {
            _hunterController = GetComponentInChildren<HunterController>();
        }
        if (_actionInput == null)
        {
            _actionInput = GetComponent<ActionInput>();
        }
        if (Camera == null) Camera = GetComponentInChildren<Camera>(true);


}

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        if (IsOwner)
        {
            GetComponent<PlayerInput>().enabled = true;
            GetComponent<AudioListener>().enabled = true;
            _movementController.enabled = true;
            Camera.gameObject.SetActive(true);
            _movementController.SetAnimator(GetComponent<Animator>());
            _gameOnlineManager.setPlayerManagerLocal(this);

            GameObject uiPlayerObject = GameObject.FindWithTag("UIPlayer");
            _compteur = uiPlayerObject.transform.Find("compteur").GetComponent<TextMeshProUGUI>();

            //lifeText = _gameOnlineManager.GetLifeText();
            //score = _gameOnlineManager.GetScore();
            //_life.OnValueChanged += UpdateLifeUI;
            //UpdateLifeUI(_life.Value, _life.Value); // Pour initialiser l'affichage au démarrage
        }
        else
        {
            Camera.gameObject.SetActive(false);
        }

        // Abonnez-vous à l'événement OnValueChanged de la NetworkVariable
        _isHunterNetwork.OnValueChanged += HandleTeamChange;
        SwapTeamLocal(_isHunterNetwork.Value);
        //--


    }


    private void UpdateLifeUI(int oldValue, int newValue)
    {
        //// Mettez à jour votre élément UI ici
        //Debug.Log(lifeText);
        //Debug.Log(oldValue);
        //if (lifeText != null)
        //{
        //    lifeText.text = "Vie : " + newValue;
        //    if(newValue <= 0) lifeText.text = "Eliminée";
        //}
    }

    public void UpdateCompteurUI(String text)
    {
        _compteur.text = text.ToString();
    }


    // Appelé lorsque la NetworkVariable change
    private void HandleTeamChange(bool oldValue, bool newValue)
    {
        // Mettez à jour la logique de changement d'équipe ici
        SwapTeamLocal(newValue);
    }

    public void EnableInputState(bool state)
    {
        if (IsOwner)
        {
            GetComponent<PlayerInput>().enabled = state;
        }
    }

    public bool IsHunter
    {
        get { return _isHunterNetwork.Value; }
    }
    public int Life
    {
        get { return _life.Value; }
    }

    public void SetSpawn(UnityEngine.Vector3 spawnPoint)
    {
        _spawnPoint = spawnPoint;

    }


    // Méthode appelée localement pour changer d'équipe
    private void SwapTeamLocal(bool isHunter)
    {
        if (isHunter)
        {
            _movementController.ClassController = _hunterController;
            _actionInput.SetClassInput(_hunterController.ClassInput);
            _propController.Deactivate();
            _hunterController.Activate();
            return;
        }
        _movementController.ClassController = _propController;
        _actionInput.SetClassInput(_propController.ClassInput);
        _hunterController.Deactivate();
        _propController.Activate();
    }

    // ServerRpc pour demander le changement d'équipe
    [ServerRpc]
    public void RequestSwapTeamServerRpc()
    {
        _isHunterNetwork.Value = !_isHunterNetwork.Value;
    }

    //[ServerRpc]
    //public void RequestLostLifeServerRpc()
    //{
    //    if(_life.Value >0)
    //    {
    //        _life.Value--;
    //        if (_life.Value < 0 && IsHost) _gameOnlineManager.CheckForGameOver();
    //    }
    //}
    public void TakeDamage(int value)
    {
        if (_life.Value > 0)
        {
            _life.Value -= value;
            if (_life.Value <= 0)
            {
                if (_isHunterNetwork.Value) _hunterController.Deactivate();
                else _propController.Deactivate();
                Debug.Log("Eliminé");

                _gameOnlineManager.CheckForGameOver();
            }

        }
    }
    
    public void TeleportToPos(UnityEngine.Vector3 _vector)
    {
           StartCoroutine(PlacePlayerCoroutine(_vector));

    }

    private IEnumerator PlacePlayerCoroutine(UnityEngine.Vector3 _vector)
    {
        yield return new WaitForEndOfFrame();
        this.gameObject.transform.position = _vector;


    }

    // Méthode appelée par l'entrée utilisateur pour changer d'équipe
    public void SwapTeam()
    {
        if (IsOwner)
        {
            RequestSwapTeamServerRpc();
        }
    }

    public void ToggleCursorLock()
    {
        bool isLocked = !_movementController.cursorLocked;
        Cursor.lockState = isLocked ? CursorLockMode.Locked : CursorLockMode.None;
        _movementController.cursorLocked = isLocked;
    }
    public void Respawn()
    {
        //faire respawn au dernier point
        TeleportToPos(_spawnPoint);
    }


   

}
