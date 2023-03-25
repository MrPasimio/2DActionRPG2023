using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Lesson 9 Add Events Library
using UnityEngine.Events;

public class Character : MonoBehaviour
{

    //Lesson 9 variables

    public enum Team
    {
        Player,
        Enemy
    }

    public string displayName;
    public int curHp;
    public int maxHp;

    [SerializeField] private Team team;

    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip hitSFX;

    public event UnityAction onTakeDamage;
    public event UnityAction onHeal;
}
