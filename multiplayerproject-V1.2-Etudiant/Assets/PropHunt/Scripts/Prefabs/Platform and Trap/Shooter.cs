using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public Transform target; // Référence au transform du joueur
    public float rotationSpeed = 2.0f; // Vitesse de rotation de la tourelle
    public GameObject bulletPrefab; // Prefab du projectile
    public float fireRate = 1.5f; // Taux de tir (temps en secondes entre les tirs)
    
    private bool isShooting = false;

    public Transform firePoint; // Point de feu pour instancier les balles

    private void Update()
    {
        if (target != null)
        {
            RotateTowardsTarget();
            TryShoot();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Transform playerTransform = other.gameObject.transform.root.gameObject.transform;
        PlayerManager playerColManager = other.gameObject.transform.root.gameObject.GetComponent<PlayerManager>();

        if (playerColManager != null)
        {
            target = playerTransform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Transform playerTransform = other.gameObject.transform.root.gameObject.transform;
        PlayerManager playerColManager = other.gameObject.transform.root.gameObject.GetComponent<PlayerManager>();

        if (playerColManager != null)
        {
            target = null;
        }
    }

    private void RotateTowardsTarget()
    {
        Vector3 targetDirection = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(targetDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }

    private void TryShoot()
    {
        if (isShooting) return;

        Vector3 targetDirection = target.position - transform.position;
        float angleToTarget = Vector3.Angle(transform.forward, targetDirection);

        if (angleToTarget < 30.0f)
        {
            StartCoroutine(Shoot());
        }
    }

    private IEnumerator Shoot()
    {
        isShooting = true;

        // Création et lancement du projectile
        GameObject bulletInstance = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bulletScript = bulletInstance.GetComponent<Bullet>();

        if (bulletScript != null)
        {
            Vector3 shootingDirection = (target.position - firePoint.position).normalized;
            //shootingDirection.y += 0.27f; // Vous pouvez ajuster cette valeur pour obtenir l'angle souhaité
            bulletScript.Initialize(shootingDirection);

        }

        Debug.Log("Tir");

        yield return new WaitForSeconds(fireRate);

        isShooting = false;
    }

}
