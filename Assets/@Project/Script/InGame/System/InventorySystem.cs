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
        var item = items.Find(x => x.ID == id);

        if (item == null)
        {
            Item newItem = new Item();
            
            newItem.Initialize(id,amount);
            
            items.Add(newItem);
        }
        else
        {
            item.Add(amount);
        }
    }

    public void RemoveItem(int id, int amount)
    {
        var item = items.Find(x => x.ID == id);

        if (item != null)
        {
            item.TryConsume(amount);

            if (item.Amount <= 0)
            {
                items.Remove(item);
            }
        }
    }
}

[System.Serializable]
public class Item
{
    private int id;
    private int _amount;
    private int _consume;
    private int _condition;

    public int ID => id;
    public int Amount => _amount;

    public void Initialize(int fieldID,int amount)
    {
        id = fieldID;
        _amount = amount;
        _consume = 0;
        _condition = _amount;
    }
    
    public void Add(int count)
    {
        _condition += count;
        _amount += count;
    }

    public bool TryConsume(int amount)
    {
        if (_amount < amount)
        {
            return false;
        }
        
        _amount -= amount;
        _consume += amount;

        if (_condition != _consume + _amount)
        {
            
        }

        return true;
    }
}

public enum Enum_ResourceType
{
    Iron,
    Crystal,
    Cogwheel,
}