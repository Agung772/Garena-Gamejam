using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatProjectile : MonoBehaviour
{
    public int damage;
    public int exp;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterStat>())
        {
            other.GetComponent<CharacterStat>().Hit(damage, exp);
            GetComponent<EfectProjectile>().Stop(0);
        }
    }
}
