using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private itemsData[] starterItems;
    [SerializeField] private int inventorySize;
    private ItemSlot[] itemSlots;

    public InventoryUI UI;

    public static Inventory Instance;

     void Awake()
     {
        if (Instance != null && Instance != this)
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
            // Initialize the item slots.
     itemSlots = new ItemSlot[inventorySize];
            for (int i = 0; i < itemSlots.Length; i++)
            {
                itemSlots[i] = new ItemSlot();
            }
            // Add the starter items.
            for (int i = 0; i < starterItems.Length; i++)
            {
                AddItem(starterItems[i]);
            }
     }
        // Adds an item to the inventory.
     public void AddItem(itemsData item)
     {
            ItemSlot slot = FindAvailableItemSlot(item);
            if (slot != null)
            {
                slot.Quantiy++;
            UI.UpdateUI(itemSlots);
            return;
            }
            slot = GetEmptySlot();
            if (slot != null)
            {
                slot.Item = item;
                slot.Quantiy = 1;
            }
            else
            {
                Debug.Log("Inventory is full!");
                return;
            }
        UI.UpdateUI(itemSlots);
     }
        // Removes the requested item from the inventory.
        public void RemoveItem(itemsData item)
        {
            for (int i = 0; i < itemSlots.Length; i++)
            {
                if (itemSlots[i].Item == item)
                {
                    RemoveItem(itemSlots[i]);
                    return;
                }
            }
        }
        // Removes an item from the requested slot.
        public void RemoveItem(ItemSlot slot)
        {
            if (slot == null)
            {
                Debug.LogError("Can't remove item from inventory!");
                return;
            }

            slot.Quantiy--;

            if (slot.Quantiy <= 0)
            {
                slot.Item = null;
                slot.Quantiy = 0;
            }
          UI.UpdateUI(itemSlots);
        }
        // Returns in item slot that the requested item can fit into.
        ItemSlot FindAvailableItemSlot(itemsData item)
        {
            for (int i = 0; i < itemSlots.Length; i++)
            {
                if (itemSlots[i].Item == item && itemSlots[i].Quantiy < item.MaxStackSize)
                    return itemSlots[i];
            }
            return null;
        }
        // Returns an item slot without any item in it.
        ItemSlot GetEmptySlot()
        {
            for (int i = 0; i < itemSlots.Length; i++)
            {
                if (itemSlots[i].Item == null)
                    return itemSlots[i];
            }
            return null;
        }
        // Called when we click on an item slot.
        public void UseItem(ItemSlot slot)
        {
            if (slot.Item is MeleeWeaponItemData || slot.Item is RangedWeaponItemData)
            {
                Player.Instance.EquipCtrl.Equip(slot.Item);
            }
            else if (slot.Item is FoodItemData)
            {
                FoodItemData food = slot.Item as FoodItemData;
                Player.Instance.Heal(food.HealthToGive);

                RemoveItem(slot);
            }
        }
        // Do we have the requested item?
        public bool HasItem(itemsData item)
        {
            for (int i = 0; i < itemSlots.Length; i++)
            {
                if (itemSlots[i].Item == item && itemSlots[i].Quantiy > 0)
                {
                return true;
                }
                    
            }
            return false;
        }
    }
