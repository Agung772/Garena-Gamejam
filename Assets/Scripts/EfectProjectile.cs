using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfectProjectile : MonoBehaviour
{
    public ParticleSystem efectSentuhan, projectile, efectSpawn, efeckPerticle, beamParticle;


    private void Start()
    {
        efectSpawn.Play();
        Destroy(gameObject, 5f);
    }

    public void Stop(float time)
    {
        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            yield return new WaitForSeconds(time);
            efeckPerticle.Stop();
            efeckPerticle.transform.parent = null;
            Destroy(efeckPerticle.gameObject, 2);

            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
