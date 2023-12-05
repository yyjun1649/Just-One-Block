using UnityEngine;
using System.Collections.Generic;

public class InventorySystem : PlaySystem
{
    private List<Item> items = new List<Item>();
    [SerializeField] private UI_Inventory _uiInventory;

    public List<Item> Items => items;
    
    private List<Item> Existitems = new List<Item>();

    public override void Initialize()
    {
        var spec = SpecDataManager.Instance.SpecItemData;
        for (int i = items.Count; i < spec.Count; i++)
        {
            var item = new Item();
            item.Initialize(i,0);
            items.Add(item);
        }
        
        ShowOffUI();
    }

    public List<Item> GetExistItem()
    {
        Existitems.Clear();

        foreach (var item in items)
        {
            if (item.Amount > 0)
            {
                Existitems.Add(item);
            }
        }

        return Existitems;
    }

    public void ShowUI()
    {
        _uiInventory.Initialize();
    }

    public void ShowOffUI()
    {
        _uiInventory.Close();
    }

    public void AddItem(int id, int amount)
    {
        var item = items[id];
        
        item.Add(amount);
    }
}

[System.Serializable]
public class Item
{
    private int _amount;
    private int _consume;
    private int _condition;
    
    public int Amount => _amount;
    private SpecItem _spec;
    
    public SpecItem Spec => _spec;

    public void Initialize(int fieldID,int amount)
    {
        _amount = amount;
        _consume = 0;
        _condition = _amount;
        _spec = SpecDataManager.Instance.SpecItemData[fieldID];
    }
    
    public void Add(int count)
    {
        _condition += count;
        _amount += count;
    }

    public bool IsEnough(int amount)
    {
        if (_amount < amount)
        {
            return false;
        }

        return true;
    }

    public bool TryConsume(int amount)
    {
        if (!IsEnough(amount))
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