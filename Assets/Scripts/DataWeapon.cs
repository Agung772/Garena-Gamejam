using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataWeapon : MonoBehaviour
{
    public float damage;
    public float forceSpeed;
    public float atkSpeed;
    public float range;

    public Transform point;
    public GameObject projectilePrefab;

    bool cooldown;
    private void Update()
    {
        if (!cooldown)
        {
            cooldown = true;
            Debug.Log("Shoot");

            GameObject projectile = Instantiate(projectilePrefab, point.position, point.rotation);
            projectile.GetComponent<Rigidbody>().AddForce(point.forward * forceSpeed, ForceMode.Impulse);

            projectile.GetComponent<StatProjectile>().damage = damage;
            projectile.GetComponent<EfectProjectile>().Stop(range);


            StartCoroutine(Coroutine());
            IEnumerator Coroutine()
            {
                yield return new WaitForSeconds(atkSpeed);
                cooldown = false;
            }
        }

    }
}
