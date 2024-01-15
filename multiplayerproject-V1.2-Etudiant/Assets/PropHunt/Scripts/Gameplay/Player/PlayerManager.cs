using System;
using System.Collections;
using System.Collections.Generic;
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

    // Utilisation de NetworkVariable pour synchroniser l'�tat isHunter
    private NetworkVariable<bool> _isHunterNetwork = new NetworkVariable<bool>();
    private NetworkVariable<int> _life = new NetworkVariable<int>(5);
    public TextMeshProUGUI lifeText; // Assurez-vous d'avoir using UnityEngine.UI;
    public TextMeshProUGUI score; // Assurez-vous d'avoir using UnityEngine.UI;


    public ActionInput _actionInput;
    public Animator _animator;
    [SerializeField] PropController _propController;
    [SerializeField] HunterController _hunterController;
    GameOnlineManager _gameOnlineManager;

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
            lifeText = _gameOnlineManager.GetLifeText();
            score = _gameOnlineManager.GetScore();
            _life.OnValueChanged += UpdateLifeUI;
            UpdateLifeUI(_life.Value, _life.Value); // Pour initialiser l'affichage au d�marrage
        }
        else
        {
            Camera.gameObject.SetActive(false);
        }

        // Abonnez-vous � l'�v�nement OnValueChanged de la NetworkVariable
        _isHunterNetwork.OnValueChanged += HandleTeamChange;
        SwapTeamLocal(_isHunterNetwork.Value);
        //--


    }


    private void UpdateLifeUI(int oldValue, int newValue)
    {
        // Mettez � jour votre �l�ment UI ici
        Debug.Log(lifeText);
        Debug.Log(oldValue);
        if (lifeText != null)
        {
            lifeText.text = "Vie : " + newValue;
            if(newValue <= 0) lifeText.text = "Elimin�e";
        }
    }


    // Appel� lorsque la NetworkVariable change
    private void HandleTeamChange(bool oldValue, bool newValue)
    {
        // Mettez � jour la logique de changement d'�quipe ici
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

    

    // M�thode appel�e localement pour changer d'�quipe
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

    // ServerRpc pour demander le changement d'�quipe
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
                Debug.Log("Elimin�");

                _gameOnlineManager.CheckForGameOver();
            }

        }
    }
    

    // M�thode appel�e par l'entr�e utilisateur pour changer d'�quipe
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




}
