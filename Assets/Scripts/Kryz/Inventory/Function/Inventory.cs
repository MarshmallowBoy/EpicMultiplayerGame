using System.Collections.Generic;
using System;
using UnityEngine;


public class Inventory : MonoBehaviour
{
    [SerializeField] List<Item> items;
    [SerializeField] Transform itemsParent;
    [SerializeField] InventorySlot[] inventorySlots;

    public event Action<Item> OnItemRightClickedEvent;

    private void Awake()
    {
        for(int i = 0; i < inventorySlots.Length; i++)
        {
            inventorySlots[i].OnRightClickEvent += OnItemRightClickedEvent;
        }
    }

    private void OnValidate()
    {
        if (itemsParent != null)
            inventorySlots = itemsParent.GetComponentsInChildren<InventorySlot>();
        RefreshUI();
    }

    private void RefreshUI()
    {
        int i = 0;
        for(; i < items.Count && i < inventorySlots.Length; i++)
        {
            inventorySlots[i].Item = items[i];
        }

        for(; i < inventorySlots.Length; i++)
        {
            inventorySlots[i].Item = null;
        }
    }

    public bool AddItem(Item item)
    {
        if(IsFull())
            return false;

        items.Add(item);
        RefreshUI();
        return true;
    }

    public bool RemoveItem(Item item)
    {
        if(items.Remove(item))
        {
            RefreshUI();
            return true;
        }
        return false;
    }

    public bool IsFull()
    {
        return items.Count >= inventorySlots.Length;
    }
}
