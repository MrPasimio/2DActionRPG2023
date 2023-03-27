using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEquipItem : EquipItem
{
    [SerializeField] private LayerMask hitLayerMask;
    [SerializeField] private Animator anim;
    private float LastAttackTime;

    [SerializeField] private AudioClip swingSFX;

    public override void OnUse()
    {
        MeleeWeaponItemData i = item as MeleeWeaponItemData;

        if(Time.time - LastAttackTime < i.AttackRate)
        {
            return;
        }

        LastAttackTime = Time.time;
        // Play attack animaton
        anim.SetTrigger("Attack");

        // shoot a raycast forward

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, i.Range, hitLayerMask); 

        // if we hit anything, damage it

        if(hit.collider != null)
        {
            IDamagable damagable = hit.collider.GetComponent<IDamagable>();

            if(damagable != null)
            {
                damagable.TakeDamage(i.Damage);
            }
        }

        // play sound effect

    }
}
