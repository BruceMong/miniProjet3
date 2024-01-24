using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TrapCreator : MonoBehaviour
{
    public GameObject trapBumperPrefab;

    public void CreateTrapBumper(Transform t)
    {
        if (trapBumperPrefab == null)
        {
            Debug.LogError("Le pr�fab trapBumperPrefab n'est pas r�f�renc�. Assurez-vous de le faire dans l'inspecteur Unity.");
            return;
        }

        Debug.Log("Cr�ation du pi�ge bumper!");

        // Charger le pr�fab "Trap Bumper" depuis les ressources
        GameObject trapBumper = Instantiate(trapBumperPrefab);

        // Ajouter le composant XRGrabInteractable au cube
        XRGrabInteractable existingGrabInteractable = trapBumper.GetComponent<XRGrabInteractable>();

        if (existingGrabInteractable == null)
        {
            XRGrabInteractable grabInteractable = trapBumper.AddComponent<XRGrabInteractable>();
            Debug.Log("XRGrabInteractable ajout� avec succ�s!");
        }
        else
        {
            Debug.LogWarning("Le composant XRGrabInteractable est d�j� attach� � trapBumper.");
        }


        // Ajuster la position pour qu'il apparaisse � une nouvelle position par rapport � la position du contr�leur
        trapBumper.transform.position = new Vector3(t.position.x + t.forward.x * 0.5f, t.position.y + 15f, t.position.z + t.forward.z * 0.5f);



    }
}
