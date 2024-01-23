using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CubeCreator : MonoBehaviour
{
    public static void CreateCube(Transform t)
    {
        // Créer un cube à la position spécifiée
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

        // Ajuster la position pour qu'il apparaisse légèrement en avant et en hauteur par rapport à la position de t
        cube.transform.position = t.position + t.forward * 0.5f + Vector3.up * 0.25f;

        // Appliquer le layer "Grabbable" au cube
        cube.layer = LayerMask.NameToLayer("Grabbable");

        // Ajouter le composant XRGrabInteractable au cube
        XRGrabInteractable grabInteractable = cube.AddComponent<XRGrabInteractable>();

        // Ajouter le composant BoxCollider au cube
        BoxCollider boxCollider = cube.AddComponent<BoxCollider>();

        // Configurer la taille du BoxCollider
        boxCollider.size = new Vector3(1f, 1f, 1f);

        // Appliquer les transformations de scale
        cube.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
    }
}
