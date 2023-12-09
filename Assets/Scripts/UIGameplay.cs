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

        CharacterStat characterStat = Player.instance.GetComponent<CharacterStat>();
        DataGame.instance.AddHighLevel(characterStat.level);

        highLevelText.text = "High Level : " + DataGame.instance.dataClass.highLevel;
        levelText.text = "Level : " + characterStat.level;

        Player.instance.canMove = false;
    }
}
