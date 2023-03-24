using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEquipItme : MonoBehaviour
{
    [SerializeField] private LayerMask hitLayerMask;
    [SerializeField] private Animator anim;
    private float LastAttackTime;

    [SerializeField] private AudioClip swingSFX;

    public override void OnUse()
    {
        MeleeWeaponItemData
    }
}
