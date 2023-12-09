using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CharacterStat : MonoBehaviour
{
    [SerializeField] float maxHp;
    [SerializeField] float hp;
    public int level = 1;

    [SerializeField] Image barHP;
    [SerializeField] TextMeshProUGUI levelText;

    public GameObject[] weapons;
    bool[] unlock;
    private void Start()
    {
        hp = maxHp;
        unlock = new bool[weapons.Length];

        if(GetComponent<Player>() == null) AddExp(Random.Range(0, 15));
        else AddExp(0);


        for (int i = 0; i < weapons.Length; i++)
        {
            if (i == 0) { weapons[i].SetActive(true); unlock[i] = true; }
            else weapons[i].SetActive(false);
        }


    }
    public void Hit(float amountDamage, float amountExp)
    {
        float damageBonus = 0;
        if (level > amountExp) damageBonus = 0;
        else damageBonus =  amountExp - level;


        hp -= amountDamage + damageBonus;
        barHP.fillAmount = hp / maxHp;

        Debug.Log("Damage bonus " + damageBonus + " Total damage " + (amountDamage + damageBonus));
        AudioManager.instance.SetSFX(AudioManager.instance.SFXHit);

        if (hp <= 0)
        {
            hp = 0;
            
            for (int i = 0; i < level; i++)
            {
                Vector3 randomV3 = new Vector3(Random.RandomRange(-1.5f, 1.5f), 0.5f, 0);
                Instantiate(AssetGameplay.instance.expPrefab, transform.position + randomV3, Quaternion.identity);
            }

            if (GetComponent<Player>()) UIGameplay.instance.GameOverUI();

            Destroy(gameObject);
        }
    }

    public void AddExp(int value)
    {
        level += value;
        levelText.text = "Level " + level;

        for (var i = LevelManager.instance.unlockWeapon.Length - 1; i >= 0; i--)
        {
            if (level >= LevelManager.instance.unlockWeapon[i] && !unlock[i])
            {
                weapons[i].SetActive(true);
                unlock[i] = true;
            }
        }

    }
}
