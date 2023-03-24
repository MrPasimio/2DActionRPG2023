using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ranged Weapon Item Deta", menuName = "Item/Ranged Weapon Item Deta")]
public class RangedWeaponItemDeta : itemsDeta
{
    [Header("Ranged Weapon Deta")]
    public float FireRate;
    public GameObject ProjectilePrefab;
    public itemsDeta ProjectileItemDeta;

    public void Fire (Vector3 spawnPosltion, Quaternion spawnRotation, character.Team team)
    {

    }
}
