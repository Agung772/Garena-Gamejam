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
            SpawnExp.instance.currentExp -= 1;

            if (other.GetComponent<Player>()) AudioManager.instance.SetSFX(AudioManager.instance.SFXExp);

            Destroy(gameObject);
        }
        if (other.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
