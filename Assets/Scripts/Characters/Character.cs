using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Lesson 9 Add Events Library
using UnityEngine.Events;

//L13 - Made the class abstract
public abstract class Character : MonoBehaviour, IDamagable  //L10 add the IDamagable Interface
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

    //L13 - Changed private to protected
    [SerializeField] protected Team team;

    [Header("Audio")]
    [SerializeField] protected AudioSource audioSource;
    [SerializeField] protected AudioClip hitSFX;

    public event UnityAction onTakeDamage;
    public event UnityAction onHeal;


    //L10 Add IDamageable Methods
    //L13 Added virtual to allow overrides
    public virtual void TakeDamage(int damageToTake)
    {
        curHp -= damageToTake;
        audioSource.PlayOneShot(hitSFX);
        onTakeDamage?.Invoke();

        if (curHp <= 0)
        {
            Die();
        }
       
    }

    public virtual void Die()
    {
        //L12 Added Virtual to include the override ability.

    }

    public Team GetTeam()
    {
        return team;
    }

    //L10 Add Heal method
    public virtual void Heal(int healAmount)
    {
        curHp += healAmount;

        if(curHp > maxHp)
        {
            curHp = maxHp;
        }

        onHeal?.Invoke();
    }
}
