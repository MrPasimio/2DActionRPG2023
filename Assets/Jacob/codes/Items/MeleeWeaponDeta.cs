using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Melee Weapon Item Deta", menuName = "Item/Melee Weapon Item Deta")]
public class MeleeItemDeta : itemsDeta
{
    [Header("Melee Weapon Deta")]
    public int Damage;
    public float Range;
    public float AttackRate;
}
