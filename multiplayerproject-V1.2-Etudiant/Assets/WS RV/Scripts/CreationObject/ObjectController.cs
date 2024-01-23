using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class RobotController : MonoBehaviour
{
    [SerializeField]
    private XRRayInteractor ray;

    [SerializeField]
    private InputActionReference createCubeAction;

    private bool hasBeenClicked = false;

    // ...

    private void OnEnable()
    {
        createCubeAction.action.Enable();
    }

    private void OnDisable()
    {
        createCubeAction.action.Disable();
    }

    private void Update()
    {
        if (createCubeAction.action.triggered)
        {
            if (!hasBeenClicked)
            {
                FirstClicked(transform);
                hasBeenClicked = true;
            }
            else
            {
                // Si vous souhaitez effectuer une action diff�rente apr�s le premier clic,
                // vous pouvez le g�rer ici.
            }
        }
        else
        {
            // R�initialiser le statut de clic lorsque le bouton est rel�ch�
            hasBeenClicked = false;
        }
    }

    public void FirstClicked(Transform t)
    {
        CubeCreator.CreateCube(t);

        // D�sactiver le rayon apr�s avoir cr�� le cube (si applicable)
        if (ray != null)
        {
            ray.enabled = false;
        }
    }
}
