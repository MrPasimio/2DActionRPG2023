using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Melee Weapon Item Data", menuName = "Item/Melee Weapon Item Data")]
public class MeleeItemData : itemsData
{
    [Header("Melee Weapon Data")]
    public int Damage;
    public float Range;
    public float AttackRate;
}
