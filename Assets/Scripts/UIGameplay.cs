using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIGameplay : MonoBehaviour
{
    public static UIGameplay instance;

    public TextMeshProUGUI gameTimeText;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    public void GameOverUI()
    {

    }
}
