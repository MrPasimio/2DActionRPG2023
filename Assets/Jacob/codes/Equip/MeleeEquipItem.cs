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

        // shoot a raycast forward
        // if we hit anything, damage it
        // play sound effect

    }
}
