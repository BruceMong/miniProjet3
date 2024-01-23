using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class VerrouillerObject : MonoBehaviour
{
    private XRRayInteractor xrRayInteractor;

    private void Start()
    {
        xrRayInteractor = GetComponent<XRRayInteractor>();

        if (xrRayInteractor == null)
        {
            Debug.LogError("L'interacteur XR Ray n'est pas attach� au GameObject.");
        }
        else
        {
            Debug.Log("Interacteur XR Ray attach� avec succ�s.");

            xrRayInteractor.onSelectEntered.AddListener(OnSelectEntered);
            Debug.Log("Listener d'�v�nement ajout�.");
        }
    }

    private void OnSelectEntered(XRBaseInteractable interactable)
    {
        // V�rifie si l'objet est d�j� verrouill�
        bool estVerrouille = EstObjetVerrouille(interactable.gameObject);

        // Appelle la fonction appropri�e en fonction de l'�tat actuel
        if (estVerrouille)
        {
            DeverrouillerObjet(interactable.gameObject);
        }
        else
        {
            VerrouillerObjet(interactable.gameObject);
        }
    }

    private void VerrouillerObjet(GameObject objetAVerrouiller)
    {
        // D�sactiver le composant XRGrabInteractable pour verrouiller l'objet
        XRGrabInteractable grabInteractable = objetAVerrouiller.GetComponent<XRGrabInteractable>();

        if (grabInteractable != null)
        {
            grabInteractable.enabled = false;
            Debug.Log("Objet verrouill� : " + objetAVerrouiller.name);
        }
        else
        {
            Debug.LogWarning("Aucun composant XRGrabInteractable trouv� sur l'objet.");
        }
    }

    private void DeverrouillerObjet(GameObject objetADeverrouiller)
    {
        // Activer le composant XRGrabInteractable pour d�verrouiller l'objet
        XRGrabInteractable grabInteractable = objetADeverrouiller.GetComponent<XRGrabInteractable>();

        if (grabInteractable != null)
        {
            grabInteractable.enabled = true;
            Debug.Log("Objet d�verrouill� : " + objetADeverrouiller.name);
        }
        else
        {
            Debug.LogWarning("Aucun composant XRGrabInteractable trouv� sur l'objet.");
        }
    }

    private bool EstObjetVerrouille(GameObject objet)
    {
        // V�rifie si l'objet est verrouill� en regardant l'�tat du composant XRGrabInteractable
        XRGrabInteractable grabInteractable = objet.GetComponent<XRGrabInteractable>();
        return grabInteractable != null && !grabInteractable.enabled;
    }
}
