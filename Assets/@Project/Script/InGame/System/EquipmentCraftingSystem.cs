using System.Collections.Generic;
using UnityEngine;

public class EquipmentCraftingSystem : PlaySystem
{
    [SerializeField] private UI_Craft _uiCraft;

    private List<SpecItemCraft> craft = new List<SpecItemCraft>();
    
    public override void Initialize()
    {
        ShowOffUI();
    }

    public void ShowUI()
    {
        _uiCraft.Initialize();
    }

    public void ShowOffUI()
    {
        _uiCraft.Close();
    }
    
    public List<SpecItemCraft> FindEnableCraftList()
    {
        craft.Clear();
        var specDatas = SpecDataManager.Instance.SpecItemCraftData;

        foreach (var spec in specDatas)
        {
            if (spec.IsHaveResource())
            {
                craft.Add(spec);
            }
        }

        return craft;
    }
    
    public bool IsEnableCraft(SpecItemCraft specCraft)
    {
        var inventory = InGameManager.Instance.InventorySystem.Items;

        var resourceID = specCraft.resourceItemId;
        var resourceCount = specCraft.resourceCount;

        for (int i = 0; i < resourceID.Count; i++)
        {
            var item = inventory[resourceID[i]];

            if (!item.IsEnough(resourceCount[i]))
            {
                return false;
            }
        }

        return true;
    }

    public bool TryCraft(SpecItemCraft specCraft)
    {
        if (!IsEnableCraft(specCraft))
        {
            return false;
        }
        
        var inventory = InGameManager.Instance.InventorySystem.Items;

        var resourceID = specCraft.resourceItemId;
        var resourceCount = specCraft.resourceCount;
        
        for (int i = 0; i < resourceID.Count; i++)
        {
            var item = inventory[resourceID[i]];
            
            item.TryConsume(resourceCount[i]);
        }
        return true;
    }
}