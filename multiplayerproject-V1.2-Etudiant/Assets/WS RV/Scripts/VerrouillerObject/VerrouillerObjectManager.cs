using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class VerrouillerObjectManager : MonoBehaviour
{
    [SerializeField]
    private XRRayInteractor lockRay;

    [SerializeField]
    private InputActionReference lockAction;

    private XRGrabInteractable grabInteractable;  // Utilisez XRGrabInteractable au lieu de XRGrabInteractor

    // Start is called before the first frame update
    void Start()
    {
        lockRay.enabled = false;

        lockAction.action.Enable();
        lockAction.action.performed += OnLockToggle;

        // R�cup�rer le composant XR Grab Interactable sur cet objet
        grabInteractable = GetComponent<XRGrabInteractable>();
    }

    private void OnLockToggle(InputAction.CallbackContext context)
    {
        // Inverser l'�tat de verrouillage � chaque pression du bouton
        bool isLocked = !lockRay.enabled;

        // Activer ou d�sactiver le rayon en fonction de l'�tat de verrouillage
        lockRay.enabled = isLocked;

        // Appeler la fonction de verrouillage/d�verrouillage de l'objet ici
        ChangeObjectState(isLocked);
    }

    private void ChangeObjectState(bool isLocked)
    {
        Debug.Log(isLocked ? "Object Locked" : "Object Unlocked");

        // D�sactiver le composant XR Grab Interactable
        if (grabInteractable != null)
        {
            grabInteractable.enabled = !isLocked;
        }
    }
}
