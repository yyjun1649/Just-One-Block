using UnityEngine;

public class EquipmentCraftingSystem : PlaySystem
{
    [SerializeField] private UI_Craft _uiCraft;
    
    public void ShowUI()
    {
        _uiCraft.Initialize();
    }

    public void ShowOffUI()
    {
        _uiCraft.Close();
    }
    
    public void CraftEquipment()
    {
        
    }
}