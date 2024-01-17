using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBumper : MonoBehaviour
{
    public float forceMagnitude = 1000f; // Ajustez cette valeur en fonction de la force souhaitée

    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.gameObject);
        //Debug.Log(collision.gameObject.GetType());

        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Debug.Log("Bump");

            Rigidbody playerRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            ActionInput actionInput = collision.gameObject.GetComponent<ActionInput>();

            

            if (playerRigidbody != null)
            {
                //actionInput.jump = true; // marche pas c'est pas ouf

                Vector3 direction = collision.transform.position - transform.position;
                direction = -direction.normalized;

                // Appliquez la force
                playerRigidbody.AddForce(direction * forceMagnitude, ForceMode.Impulse);
            }
        }
    }
}
