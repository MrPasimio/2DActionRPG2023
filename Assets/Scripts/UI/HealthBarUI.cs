using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//L15 Add Libraries
using UnityEngine.UI;
using TMPro;

public class HealthBarUI : MonoBehaviour
{
    //L15 variables
    [SerializeField] private Character character;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] Image healthBarFill;


    void SetNameText(string text)
    {
        nameText.text = text;
    }

    void UpdateHealthBar()
    {
        float healthPercent = (float)character.curHp / (float)character.maxHp;
        healthBarFill.fillAmount = healthPercent;
    }

    //Lesson 16
    private void Start()
    {
        SetNameText(character.displayName);
    }

    private void OnEnable()
    {
        character.onTakeDamage += UpdateHealthBar;
        character.onHeal += UpdateHealthBar;
    }

    private void OnDisable()
    {
        character.onTakeDamage -= UpdateHealthBar;
        character.onHeal -= UpdateHealthBar;
    }
}
