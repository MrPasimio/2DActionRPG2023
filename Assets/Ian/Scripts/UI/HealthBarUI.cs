using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] private Character character;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private Image healthBarFill;

    
    void SetNameText (string text)
    {
        nameText.text = text;
    }

    void UpdateHealthBar ()
    {
        float healthPercent = (float)character.CurHp / (float)character.MaxHp;
        healthBarFill.fillAmount = healthPercent;
    }
}
