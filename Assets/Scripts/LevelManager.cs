using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public float maxTime = 60;
    public float gameTime;

    UIGameplay uIGameplay;

    public int[] unlockWeapon;

    public bool active;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        uIGameplay = UIGameplay.instance;

        gameTime = maxTime;
    }
    private void Update()
    {
        GameTime();
    }

    void GameTime()
    {


        float menit = Mathf.FloorToInt(gameTime / 60);
        float detik = Mathf.FloorToInt(gameTime % 60);
        uIGameplay.gameTimeText.text = "Game time : " + string.Format("{0:00}:{1:00}", menit, detik);

        if (gameTime <= 0 && !active)
        {
            active = true;
            gameTime = 0;
            uIGameplay.GameOverUI();
        }
        else if (gameTime > 0 && !active)
        {
            gameTime -= Time.deltaTime;
        }
    }
}
