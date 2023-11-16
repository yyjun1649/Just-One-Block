using UnityEngine;

public class EquipmentCraftingSystem : MonoBehaviour
{
    [SerializeField] private UI_Craft _uiCraft;
    
    public void ShowUI()
    {
        _uiCraft.Initialize();
    }
    
    public void CraftEquipment()
    {
        
    }
}