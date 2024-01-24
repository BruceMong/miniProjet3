/*using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TrapCreator : MonoBehaviour
{
    public GameObject trapBumper;

    public static void CreateTrapBumper(Transform t)
    {
        // Assurez-vous que trapBumper est initialisé à l'avance
        if (trapBumper == null)
        {
            Debug.LogError("trapBumper n'est pas initialisé. Assurez-vous de le faire dans l'inspecteur Unity ou dans votre code.");
            return;
        }
         
        // Ajuster la position pour qu'il apparaisse légèrement en avant et en hauteur par rapport à la position du contrôleur
        trapBumper.transform.position = t.position + t.forward * 0.5f + Vector3.up * 0.25f;

        // Appliquer le layer "Grabbable" au cube
        trapBumper.layer = LayerMask.NameToLayer("Grabbable");

        // Ajouter le composant XRGrabInteractable au cube
        XRGrabInteractable grabInteractable = trapBumper.AddComponent<XRGrabInteractable>();

        // Ajouter le composant BoxCollider au cube
        BoxCollider boxCollider = trapBumper.AddComponent<BoxCollider>();

        // Configurer la taille du BoxCollider
        boxCollider.size = new Vector3(1f, 1f, 1f);

        // Appliquer les transformations de scale
        trapBumper.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
    }
}
*/