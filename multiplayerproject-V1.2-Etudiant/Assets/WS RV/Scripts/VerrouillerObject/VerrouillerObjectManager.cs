using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class VerrouillerObjectManager : MonoBehaviour
{
    [SerializeField]
    private XRRayInteractor lockRay;

    [SerializeField]
    private InputActionReference lockAction;

    private bool isLocked = false;

    // Start is called before the first frame update
    void Start()
    {
        lockRay.enabled = false;

        lockAction.action.Enable();
        lockAction.action.performed += OnLockToggle;
    }

    private void OnLockToggle(InputAction.CallbackContext context)
    {
        // Inverser l'�tat de verrouillage � chaque pression du bouton
        isLocked = !isLocked;

        // Activer ou d�sactiver le rayon en fonction de l'�tat de verrouillage
        lockRay.enabled = isLocked;

        // Appeler la fonction de verrouillage/d�verrouillage de l'objet ici
        if (isLocked)
        {
            LockObject();
        }
        else
        {
            UnlockObject();
        }
    }

    private void LockObject()
    {
        // Logique pour verrouiller l'objet
        Debug.Log("Object Locked");
        // Utilise la logique sp�cifique de VerrouillerObject si n�cessaire
    }

    private void UnlockObject()
    {
        // Logique pour d�verrouiller l'objet
        Debug.Log("Object Unlocked");
        // Utilise la logique sp�cifique de VerrouillerObject si n�cessaire
    }

    // Update is called once per frame
    void Update()
    {
        // Tu peux toujours utiliser le rayon ici pour des v�rifications suppl�mentaires si n�cessaire
        if (isLocked && lockRay.enabled)
        {
            RaycastHit hit;
            if (lockRay.TryGetCurrent3DRaycastHit(out hit))
            {
                GameObject objectToLock = hit.collider.gameObject;
                // Logique pour verrouiller/d�verrouiller l'objet ici
            }
        }
    }
}
