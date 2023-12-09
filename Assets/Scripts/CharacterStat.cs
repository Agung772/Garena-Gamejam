using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CharacterStat : MonoBehaviour
{
    [SerializeField] float maxHp;
    [SerializeField] float hp;
    public int exp = 1;

    [SerializeField] Image barHP;
    [SerializeField] TextMeshProUGUI expText;

    [SerializeField] GameObject[] weapons;
    bool[] unlock;
    private void Start()
    {
        hp = maxHp;
        unlock = new bool[weapons.Length];
        AddExp(0);


        for (int i = 0; i < weapons.Length; i++)
        {
            if (i == 0) { weapons[i].SetActive(true); unlock[i] = true; }
            else weapons[i].SetActive(false);
        }


    }
    public void Hit(float amountDamage, float amountExp)
    {
        float damageBonus = 0;
        if (exp > amountExp) damageBonus = 0;
        else damageBonus =  amountExp - exp;


        hp -= amountDamage + damageBonus;
        barHP.fillAmount = hp / maxHp;

        Debug.Log("Damage bonus " + damageBonus + " Total damage " + (amountDamage + damageBonus));

        if (hp <= 0)
        {
            hp = 0;
            
            for (int i = 0; i < exp; i++)
            {
                Vector3 randomV3 = new Vector3(Random.RandomRange(-3f, 3f), 0, 0);
                Instantiate(AssetGameplay.instance.expPrefab, transform.position + randomV3, Quaternion.identity);
            }

            Destroy(gameObject);
        }
    }

    public void AddExp(int value)
    {
        exp += value;
        expText.text = "Exp " + exp;

        for (var i = LevelManager.instance.unlockWeapon.Length - 1; i >= 0; i--)
        {
            if (exp >= LevelManager.instance.unlockWeapon[i] && !unlock[i])
            {
                weapons[i].SetActive(true);
                unlock[i] = true;
            }
        }

    }
}
