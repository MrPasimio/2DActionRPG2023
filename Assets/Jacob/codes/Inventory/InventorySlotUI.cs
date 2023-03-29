using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;
using UnityEngine.EventSystems;


public class InventorySlotUI : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI quantityText;

    private ItemSlot itemSlot;

    public void SetItemSlot(ItemSlot slot)
    {
        itemSlot = slot;

        if (slot.Item == null)
        {
            icon.enabled = false;
            quantityText.text = string.Empty;
        }
        else
        {
            icon.enabled = true;
            icon.sprite = slot.Item.Icon;
            quantityText.text = slot.Quantiy > 1 ? slot.Quantiy.ToString() : string.Empty;
        }
    }
}
