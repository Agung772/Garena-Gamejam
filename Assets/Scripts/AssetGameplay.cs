using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetGameplay : MonoBehaviour
{
    public static AssetGameplay instance;

    public GameObject expPrefab;
    public GameObject damageText;

    private void Awake()
    {
        instance = this;
    }
}
