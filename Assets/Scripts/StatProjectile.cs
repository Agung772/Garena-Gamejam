using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatProjectile : MonoBehaviour
{
    public int damage;
    public int level;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterStat>())
        {
            other.GetComponent<CharacterStat>().Hit(damage, level);

            GetComponent<EfectProjectile>().Stop(0);
        }
        else
        {
            Debug.Log(other.gameObject);
            GetComponent<EfectProjectile>().Stop(0);
        }
    }
}
