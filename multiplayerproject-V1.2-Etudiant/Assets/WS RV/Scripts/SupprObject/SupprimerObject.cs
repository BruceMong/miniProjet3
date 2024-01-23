using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupprimerObject : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // V�rifie si la touche "Delete" est enfonc�e
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            // Appelle la fonction pour supprimer l'objet
            SupprimerCetObjet();
        }
    }

    // Fonction pour supprimer l'objet
    void SupprimerCetObjet()
    {
        // D�truit cet objet
        Destroy(gameObject);
    }
}
