using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatProjectile : MonoBehaviour
{
    public float damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.activeSelf)
        {

        }
    }
}
