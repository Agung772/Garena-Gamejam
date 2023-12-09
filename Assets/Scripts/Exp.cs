using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exp : MonoBehaviour
{
    public int expAmount;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterStat>())
        {
            other.GetComponent<CharacterStat>().AddExp(expAmount);
            Destroy(gameObject);
        }
    }
}