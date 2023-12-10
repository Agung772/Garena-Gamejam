using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfectProjectile : MonoBehaviour
{
    public ParticleSystem efectSentuhan, projectile, efectSpawn, efeckPerticle, beamParticle;

    public GameObject explosion;


    private void Start()
    {
        if (efectSpawn != null) efectSpawn.Play();
        Destroy(gameObject, 5f);
    }

    public void Stop(float time)
    {
        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            yield return new WaitForSeconds(time);
            if (efeckPerticle != null) efeckPerticle.Stop();
            if (efeckPerticle != null) efeckPerticle.transform.parent = null;
            if (efeckPerticle != null) Destroy(efeckPerticle.gameObject, 2);

            if (explosion != null) explosion.SetActive(true);
            if (explosion != null) explosion.transform.parent = null;
            if (explosion != null) Destroy(explosion, 2);

            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (efectSentuhan != null) efectSentuhan.Play();
        if (efectSentuhan != null) efectSentuhan.transform.parent = null;
        if (efectSentuhan != null) Destroy(efectSentuhan.gameObject, 2);
    }
}
