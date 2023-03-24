using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Food Item Data", menuName = "Item/fFood Item Data")]
public class FoodItemData : itemsData
{
    [Header("Food Item Data")]
    public int HealthToGive;
}
