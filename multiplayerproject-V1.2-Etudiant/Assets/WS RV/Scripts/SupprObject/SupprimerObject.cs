using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupprimerObject : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // Vérifie si la touche "Delete" est enfoncée
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            // Appelle la fonction pour supprimer l'objet
            SupprimerCetObjet();
        }
    }

    // Fonction pour supprimer l'objet
    void SupprimerCetObjet()
    {
        // Détruit cet objet
        Destroy(gameObject);
    }
}
