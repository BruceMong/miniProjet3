using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 5f;
    public Vector3 direction;
    public float pushForce = 35000f; // La force de propulsion appliquée au joueur

    public void Initialize(Vector3 dir)
    {
        direction = dir.normalized;
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        PlayerManager playerColManager = other.gameObject.transform.root.gameObject.GetComponent<PlayerManager>();
        
        if (playerColManager)
        {
            Rigidbody rb  = other.gameObject.transform.root.gameObject.GetComponent<Rigidbody>();
            Debug.Log(pushForce);
            rb.AddForce(direction * pushForce, ForceMode.Impulse);
            Destroy(gameObject);
        }

        //if (other.GetComponent<CharacterController>())
        //{
        //    // Désactiver le CharacterController
        //    CharacterController characterController = other.GetComponent<CharacterController>();
        //    characterController.enabled = false;

        //    // Ajouter un Rigidbody temporaire pour appliquer la force
        //    Rigidbody rb = other.gameObject.AddComponent<Rigidbody>();
        //    rb.AddForce(direction * pushForce, ForceMode.Impulse);

        //    // Démarrer une coroutine pour réactiver le CharacterController et supprimer le Rigidbody
        //    StartCoroutine(ResetCharacterController(other.gameObject, characterController));
        //}
    }

    //IEnumerator ResetCharacterController(GameObject player, CharacterController characterController)
    //{
    //    yield return new WaitForSeconds(1f); // Attente avant de réinitialiser

    //    // Supprimer le Rigidbody temporaire
    //    Destroy(player.GetComponent<Rigidbody>());

    //    // Réactiver le CharacterController
    //    characterController.enabled = true;
    //}
}
