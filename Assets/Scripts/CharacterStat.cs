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
    private void Start()
    {
        hp = maxHp;
        AddExp(0);

        for (int i = 0; i < weapons.Length; i++)
        {
            if (i == 0) weapons[i].SetActive(true);
            else weapons[i].SetActive(false);
        }


    }
    public void Hit(float amountDamage, float amountExp)
    {
        float damageBonus = amountExp / exp;

        hp -= amountDamage + damageBonus;
        barHP.fillAmount = hp / maxHp;

        Debug.Log("Damage bonus " + damageBonus + " Total damage " + (amountDamage + damageBonus));
    }

    public void AddExp(int value)
    {
        exp += value;
        expText.text = "Exp " + exp;
    }
}
