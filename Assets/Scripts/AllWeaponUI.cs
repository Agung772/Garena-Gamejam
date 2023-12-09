using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllWeaponUI : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 0;
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
