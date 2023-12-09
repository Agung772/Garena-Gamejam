using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIGameplay : MonoBehaviour
{
    public static UIGameplay instance;

    public TextMeshProUGUI gameTimeText;

    public GameObject gameoverUI;
    public GameObject allweaponUI;
    public TextMeshProUGUI highLevelText;
    public TextMeshProUGUI levelText;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    private void Start()
    {
        allweaponUI.SetActive(true);
    }

    public void GameOverUI()
    {
        gameoverUI.SetActive(true);

        AudioManager.instance.SetSFX(AudioManager.instance.SFXGameover);
        
        CharacterStat characterStat = Player.instance.GetComponent<CharacterStat>();
        DataGame.instance.AddHighLevel(characterStat.level);

        highLevelText.text = "High Level : " + DataGame.instance.dataClass.highLevel;
        levelText.text = "Level : " + characterStat.level;

        LevelManager.instance.active = true;
        Player.instance.canMove = false;

        WeaponData[] weaponDatas = FindObjectsOfType<WeaponData>();
        for (int i = 0; i < weaponDatas.Length; i++)
        {
            weaponDatas[i].active = false;
        }
        
        NonPlayer[] nonPlayer = FindObjectsOfType<NonPlayer>();
        for (int j = 0; j < nonPlayer.Length; j++)
        {
            nonPlayer[j].Stop();
        }




    }

    public void MovingScene(string nameScene)
    {
        GameManager.instance.MovingScene(nameScene);
    }
}
