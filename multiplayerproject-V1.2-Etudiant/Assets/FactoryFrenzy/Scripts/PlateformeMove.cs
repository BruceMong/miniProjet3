using UnityEngine;


public class PlateformeMove : MonoBehaviour
{
    public Vector3 deplacement; // Déplacement par rapport au point A
    private Vector3 pointA;
    private Vector3 pointB;
    public float speed = 1.0f;

    private float t = 0.0f; // Un paramètre pour contrôler l'interpolation

    void Start()
    {
        pointA = transform.position; // Point A est la position initiale de la plateforme
        pointB = pointA + deplacement; // Point B est calculé comme un déplacement par rapport à A
    }

    void Update()
    {
        // Interpolation entre pointA et pointB
        transform.position = Vector3.Lerp(pointA, pointB, Mathf.PingPong(t, 1));
        t += Time.deltaTime * speed;
    }

    // Appelé quand un objet entre en collision avec la plateforme
    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {

            collision.transform.SetParent(transform);
        }
    }

    // Appelé quand un objet quitte la collision avec la plateforme
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            collision.transform.SetParent(null); // Détache le personnage de la plateforme
        }
    }
}