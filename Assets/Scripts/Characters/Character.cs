using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Lesson 9 Add Events Library
using UnityEngine.Events;

public class Character : MonoBehaviour, IDamagable  //L10 add the IDamagable Interface
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


    //L10 Add IDamageable Methods
    public void TakeDamage(int damageToTake)
    {
        curHp -= damageToTake;
        audioSource.PlayOneShot(hitSFX);
        onTakeDamage?.Invoke();

        if (curHp <= 0)
        {
            Die();
        }
       
    }

    public void Die()
    {
        
    }

    public Team GetTeam()
    {
        return team;
    }

    //L10 Add Heal method
    public void Heal(int healAmount)
    {
        curHp += healAmount;

        if(curHp > maxHp)
        {
            curHp = maxHp;
        }

        onHeal?.Invoke();
    }
}
