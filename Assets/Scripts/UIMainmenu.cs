using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIMainmenu : MonoBehaviour
{
    public TextMeshProUGUI highLevelText;

    private void Start()
    {
        AudioManager.instance.SetBGM(AudioManager.instance.mainmenuBgm);

        highLevelText.text = "High Level : " + DataGame.instance.dataClass.highLevel;
    }

    public void MovingScene(string nameScene)
    {
        GameManager.instance.MovingScene(nameScene);
    }
}
