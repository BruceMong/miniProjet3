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

        // Ajouter le composant XRGrabInteractable au trap bumper
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



        // Ajuster la position pour qu'il apparaisse � la position sp�cifi�e
        trapBumper.transform.position = new Vector3(2.049f, 1.42f, -1.299f) + new Vector3(0.1f, 0.1f, 0.1f); // Incremental adjustment

        // Ajuster l'�chelle (scale)
        trapBumper.transform.localScale = new Vector3(4f, 4f, 4f);

        // Ajouter le layer "Props"
        trapBumper.layer = LayerMask.NameToLayer("Props");

        // Optional: Adjust other settings based on your specific requirements
    }
}