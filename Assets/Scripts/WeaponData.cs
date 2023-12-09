using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponData : MonoBehaviour
{
    public CharacterStat characterStat;

    [System.Serializable]
    public enum TypeWeapon
    {
        piscok,
        bregedeg,
        basokha
    }

    public TypeWeapon typeWeapon;

    public int damage;
    public float forceSpeed;
    public float atkSpeed;
    public float range;

    public Transform point;
    public GameObject projectilePrefab;

    bool cooldown;
    public bool active;

    public AudioSource audioSource;

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

            GameObject projectile = Instantiate(projectilePrefab, point.position, point.rotation);
            projectile.GetComponent<Rigidbody>().AddForce(point.forward * forceSpeed, ForceMode.Impulse);

            projectile.GetComponent<StatProjectile>().damage = damage;
            projectile.GetComponent<StatProjectile>().level = characterStat.level;
            projectile.GetComponent<EfectProjectile>().Stop(range);


            //Audio
            if (typeWeapon == TypeWeapon.piscok) audioSource.PlayOneShot(AudioManager.instance.SFXPiscok);
            else if (typeWeapon == TypeWeapon.bregedeg) audioSource.PlayOneShot(AudioManager.instance.SFXBregedeg);
            else if (typeWeapon == TypeWeapon.basokha) audioSource.PlayOneShot(AudioManager.instance.SFXBasokha);

            StartCoroutine(Coroutine());
            IEnumerator Coroutine()
            {
                yield return new WaitForSeconds(atkSpeed);
                cooldown = false;
            }
        }

    }
}
