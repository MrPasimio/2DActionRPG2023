using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private InventorySlotUI[] uislot;
    public ItemTooltipUI TooltipUI;

    public void UpdateUi (ItemSlot[] items)
    {
       for(int i = 0; i < uislot.Length; i++)
        {
            uislot[i].SetItemSlot(items[i]);
        }
    }
}
