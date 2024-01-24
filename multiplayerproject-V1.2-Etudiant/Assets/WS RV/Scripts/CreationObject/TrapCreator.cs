using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TrapCreator : MonoBehaviour
{
    public GameObject trapBumperPrefab;

    public void CreateTrapBumper(Transform t)
    {
        if (trapBumperPrefab == null)
        {
            Debug.LogError("Le préfab trapBumperPrefab n'est pas référencé. Assurez-vous de le faire dans l'inspecteur Unity.");
            return;
        }

        Debug.Log("Création du piège bumper!");

        // Charger le préfab "Trap Bumper" depuis les ressources
        GameObject trapBumper = Instantiate(trapBumperPrefab);

        // Ajouter le composant XRGrabInteractable au cube
        XRGrabInteractable existingGrabInteractable = trapBumper.GetComponent<XRGrabInteractable>();

        if (existingGrabInteractable == null)
        {
            XRGrabInteractable grabInteractable = trapBumper.AddComponent<XRGrabInteractable>();
            Debug.Log("XRGrabInteractable ajouté avec succès!");
        }
        else
        {
            Debug.LogWarning("Le composant XRGrabInteractable est déjà attaché à trapBumper.");
        }


        // Ajuster la position pour qu'il apparaisse à une nouvelle position par rapport à la position du contrôleur
        trapBumper.transform.position = new Vector3(t.position.x + t.forward.x * 0.5f, t.position.y + 15f, t.position.z + t.forward.z * 0.5f);



    }
}
