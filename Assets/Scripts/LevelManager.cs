using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public float gameTime;

    UIGameplay uIGameplay;
    private void Start()
    {
        uIGameplay = UIGameplay.instance;
    }
    private void Update()
    {
        GameTime();
    }

    void GameTime()
    {
        gameTime += Time.deltaTime;

        float menit = Mathf.FloorToInt(gameTime / 60);
        float detik = Mathf.FloorToInt(gameTime % 60);
        uIGameplay.gameTimeText.text = string.Format("{0:00}:{1:00}", menit, detik);
    }
}
