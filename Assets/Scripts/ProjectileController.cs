using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public ParticleSystem efectSentuhan, projectile, efectSpawn, efeckPerticle, beamParticle;


    private void Start()
    {
        efectSpawn.Play();
        Destroy(gameObject, 5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            efectSentuhan.Play();
            Destroy(gameObject, 3);
            yield return new WaitForSeconds(1);
            efeckPerticle.Stop();
            projectile.Stop();
            beamParticle.Stop();
        }






        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.constraints = RigidbodyConstraints.FreezePosition;
        rb.freezeRotation = true;
        //rb.isKinematic = true;
    }
}
