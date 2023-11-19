using UnityEngine;
using System.Collections.Generic;

public class InventorySystem : PlaySystem
{
    private List<Item> items = new List<Item>();
    [SerializeField] private UI_Inventory _uiInventory;
    
    public void ShowUI()
    {
        _uiInventory.Initialize();
    }

    public void AddItem(int id, int amount)
    {
        var item = items.Find(x => x.Id == id);

        if (item == null)
        {
            Item newItem = new Item();
            
            newItem.Initialize(id,amount);
            
            items.Add(newItem);
        }
        else
        {
            item.Amount += amount;
        }
    }

    public void RemoveItem(int id, int amount)
    {
        var item = items.Find(x => x.Id == id);

        if (item.Amount > amount)
        {
            item.Amount -= amount;
        }
        else
        {
            items.Remove(item);
        }
    }
}

[System.Serializable]
public class Item
{
    public int Id;
    public int Amount;

    public void Initialize(int id,int amount)
    {
        Id = id;
        Amount = amount;
    }
}

public enum Enum_ResourceType
{
    Iron,
    Crystal,
    Cogwheel,
}