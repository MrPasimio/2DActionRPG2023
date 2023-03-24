using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ranged Weapon Item Data", menuName = "Item/Ranged Weapon Item Data")]
public class RangedWeaponItemData : itemsData
{
    [Header("Ranged Weapon Data")]
    public float FireRate;
    public GameObject ProjectilePrefab;
    public itemsData ProjectileItemDeta;

    public void Fire (Vector3 spawnPosltion, Quaternion spawnRotation, character.Team team)
    {

    }
}
