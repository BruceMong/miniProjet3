using UnityEngine;


public class PlateformeMove : MonoBehaviour
{
    public Vector3 deplacement; // D�placement par rapport au point A
    private Vector3 pointA;
    private Vector3 pointB;
    public float speed = 1.0f;

    private float t = 0.0f; // Un param�tre pour contr�ler l'interpolation

    void Start()
    {
        pointA = transform.position; // Point A est la position initiale de la plateforme
        pointB = pointA + deplacement; // Point B est calcul� comme un d�placement par rapport � A
    }

    void Update()
    {
        // Interpolation entre pointA et pointB
        transform.position = Vector3.Lerp(pointA, pointB, Mathf.PingPong(t, 1));
        t += Time.deltaTime * speed;
    }

    // Appel� quand un objet entre en collision avec la plateforme
    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {

            collision.transform.SetParent(transform);
        }
    }

    // Appel� quand un objet quitte la collision avec la plateforme
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            collision.transform.SetParent(null); // D�tache le personnage de la plateforme
        }
    }
}