using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllWeaponUI : MonoBehaviour
{
    private void Start()
    {
        UIGameplay.instance.MoveScene(false);
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            gameObject.SetActive(false);
            UIGameplay.instance.MoveScene(true);
        }
    }
}
