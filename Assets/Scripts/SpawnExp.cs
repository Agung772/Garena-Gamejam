using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnExp : MonoBehaviour
{
    public float speedSpawn;
    public float scaleX;
    public float scaleZ;

    bool cooldown;
    private void Update()
    {
        if (!cooldown)
        {
            cooldown = true;

            GameObject exp = Instantiate(AssetGameplay.instance.expPrefab, transform);
            exp.transform.position = new Vector3(Random.Range(-scaleX, scaleX), transform.position.y, Random.Range(-scaleZ, scaleZ));

            StartCoroutine(Coroutine());
            IEnumerator Coroutine()
            {
                yield return new WaitForSeconds(speedSpawn);
                cooldown = false;
            }
        }
    }
}
