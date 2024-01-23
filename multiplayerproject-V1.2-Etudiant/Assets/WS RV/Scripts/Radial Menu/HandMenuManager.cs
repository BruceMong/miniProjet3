using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandMenuManager : MonoBehaviour
{


    public InputActionReference activateRef;

    private InputAction activate;


    public HandMenu HandMenu;

    [SerializeField]
    private List<GameObject> objectToDisable;

    private void Awake()
    {
        activate = activateRef.action;



        activate.Enable();


        activate.performed += Activate;
    }

    private void OnDestroy()
    {
        activate.performed -= Activate;

    }

    private void Activate(InputAction.CallbackContext obj)
    {
        HandMenu.Show(obj.ReadValueAsButton());
        foreach (GameObject go in objectToDisable)
        {
            go.SetActive(false);
        }
    }

    public void CloseMenu()
    {
        foreach (GameObject go in objectToDisable)
        {
            go.SetActive(true);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
