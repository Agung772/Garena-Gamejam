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
        AudioManager.instance.SetBGM(AudioManager.instance.gameplayBgm);

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

        MoveScene(false);
    }

    public void MoveScene(bool value)
    {
        if (value)
        {
            LevelManager.instance.active = false;
            Player.instance.canMove = true;

            WeaponData[] weaponDatas = FindObjectsOfType<WeaponData>();
            for (int i = 0; i < weaponDatas.Length; i++)
            {
                weaponDatas[i].StartRandomActive();
            }

            CharacterStat[] characterStat = FindObjectsOfType<CharacterStat>();
            for (int j = 0; j < characterStat.Length; j++)
            {
                characterStat[j].StartStat();
            }

            NonPlayer[] nonPlayer = FindObjectsOfType<NonPlayer>();
            for (int k = 0; k < nonPlayer.Length; k++)
            {
                nonPlayer[k].Active(true);
            }
        }
        else
        {
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
                nonPlayer[j].Active(false);
            }
        }
    }

    public void MovingScene(string nameScene)
    {
        GameManager.instance.MovingScene(nameScene);
    }
}
