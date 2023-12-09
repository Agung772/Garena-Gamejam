using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponData : MonoBehaviour
{
    public CharacterStat characterStat;

    public int damage;
    public float forceSpeed;
    public float atkSpeed;
    public float range;

    public Transform point;
    public GameObject projectilePrefab;

    bool cooldown;
    bool active;

    private void OnEnable()
    {
        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            yield return new WaitForSeconds(Random.RandomRange(0f, 2f));
            active = true;
        }
    }
    private void Start()
    {

    }
    private void Update()
    {
        if (!active) return;
        if (!cooldown)
        {
            cooldown = true;
            Debug.Log("Shoot");

            GameObject projectile = Instantiate(projectilePrefab, point.position, point.rotation);
            projectile.GetComponent<Rigidbody>().AddForce(point.forward * forceSpeed, ForceMode.Impulse);

            projectile.GetComponent<StatProjectile>().damage = damage;
            projectile.GetComponent<StatProjectile>().exp = characterStat.exp;
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
