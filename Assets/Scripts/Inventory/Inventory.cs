using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private ItemData[] starterItems;
    [SerializeField] private int inventorySize;
    private ItemSlot[] itemSlots;

    public InventoryUI UI;

    public static Inventory Instance;

    void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
    }

    void Start ()
    {
        itemSlots = new ItemSlot[inventorySize];

        for(int i = 0; i < itemSlots.Length; i++)
        {
            itemSlots[i] = new ItemSlot();
        }

        for(int i = 0; i < starterItems.Length; i++)
        {
            AddItem(starterItems[i]);
        }
    }

    public void AddItem (ItemData item)
    {

    }

    public void RemoveItem (ItemData item)
    {

    }

    public void RemoveItem (ItemSlot slot)
    {

    }

    ItemSlot FindAvailableItemSlot (ItemData item)
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].Item == item && itemSlots[i].Quantity < item.MaxStackSize)
                return itemSlots[i];
        }

        return null;
    }

    ItemSlot GetEmptySlot()
    {
        for(int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].Item == null)
                return itemSlots[i];
        }

        return null;
    }

    public void UseItem (ItemSlot slot)
    {

    }

    public bool HasItem (ItemData item)
    {
        return false;
    }
}