using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private itemsData[] starterItems;
    [SerializeField] private int invetorySize;
    private ItemSlot[] ItemSlots;

    public InventoryUI UI;

    public static Inventory Instance;

    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        ItemSlots = new ItemSlot[invetorySize];

        for(int i = 0; i < ItemSlots.Length; i++)
        {
            ItemSlots[i] = new ItemSlot();
            
        }

        for(int i = 0; i < starterItems.Length; i++)
        {
            AddItem(starterItems[i]);
            
        }
    }

    public void AddItem (itemsData item)
    {
        ItemSlot slot = FindAvailableItemSlot(item);

        if(slot != null)
        {
            
            slot.Quantiy++;
            UI.UpdateUi(ItemSlots);
            return;
        }

        slot = GetEmptySlot();

        if(slot != null)
        {
            slot.Item = item;
            slot.Quantiy = 1;
        }
        else
        {
            Debug.Log("Inventory is full");
            return;
        }

        UI.UpdateUi(ItemSlots);
    }

    public void RemoveItem (itemsData item)
    {
        for(int i = 0; i < ItemSlots.Length; i++)
        {
            if(ItemSlots[i].Item == item)
            {
                RemoveItem(ItemSlots[i]);
                return;
            }
        }
    }

    public void RemoveItem (ItemSlot slot)
    {
        if(slot == null)
        {
            Debug.LogError("Can't remove Item from Inventory!");
            return;
        }

        slot.Quantiy--;

        if(slot.Quantiy <= 0)
        {
            slot.Item = null;
            slot.Quantiy = 0;
        }

        UI.UpdateUi(ItemSlots);
    }

    ItemSlot FindAvailableItemSlot (itemsData item)
    {
        for(int i = 0; i < ItemSlots.Length; i++)
        {
            if (ItemSlots[i].Item == item && ItemSlots[i].Quantiy < item.MaxStackSize)
            {
                return ItemSlots[i];
            }
        }

        return null;
    }

    ItemSlot GetEmptySlot()
    {
        for(int i = 0; i < ItemSlot.Length; i++)
        {
            if(ItemSlots[i]. Item == null)
            {
                return ItemSlots[i];
            }
        }

        return null;
    }

    public void UseItem(ItemSlot slot)
    {
        if(slot.Item is MeleeWeaponItemData || slot.Item is RangedWeaponItemData)
        {
            Player.Instance.EquipCtrl.Equip(slot.Item);
        }
        else if(slot.Item is FoodItemData)
        {
            FoodItemData food = slot.Item as FoodItemData;
            Player.Instance.Heal(food.HealthToGive);

            RemoveItem(slot);
        }
    }
    public bool HasItem (itemsData item)
    {
        for(int i = 0; i < ItemSlots.Length; i++)
        {
            if(ItemSlots[i].Item == item && ItemSlots[i].Quantiy > 0)
            {
                return true;
            }
        }

        return false;
    }
}
