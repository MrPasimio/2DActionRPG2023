using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class character : MonoBehaviour
{
    public enum Team
    {
        Player,
        Enemy
    }

    public string DisplayName;
    public int CurHp;
    public int MaxHp;

    [SerializeField] private Team team;

    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip hitSFX;

    public event UnityAction onTakeDamage;
    public event UnityAction onHeal;
}
