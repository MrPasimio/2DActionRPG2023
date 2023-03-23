using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item Deta", menuName = "Item/Generic Item")]
public class itemsDeta : ScriptableObject
{
    public string DisplayName;
    public string Description;
    public Sprite Icon;

    public int MaxStackSize = 1;

    public GameObject EquipPrefab;
}
