using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnExp : MonoBehaviour
{
    public static SpawnExp instance;

    public float speedSpawn;

    public float maxExp = 100;
    public float currentExp;

    public float scaleX;
    public float scaleZ;

    bool cooldown;

    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        if (!cooldown && currentExp < maxExp)
        {
            cooldown = true;

            currentExp += 1;
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
