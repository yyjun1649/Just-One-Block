using UnityEngine;

public class UI_Craft : UI_Base,GameEventListener<RefreshEvent>
{
    [SerializeField] private UI_CraftScroller _scroller;
    [SerializeField] private UI_CraftInfo _panelInfo;
    
    public void Initialize()
    {
        this.AddGameEventListening<RefreshEvent>();
        
        Open();
        
        Refresh();
    }

    public void Refresh()
    {
        var enableCraft = InGameManager.Instance.EquipmentCraftingSystem.FindEnableCraftList();

        SetInfoPanel(null);
        
        _scroller.SetAction(SetInfoPanel);
        _scroller.Initialize(enableCraft);
    }

    public void SetInfoPanel(SpecItemCraft specItemCraft)
    {
        _panelInfo.Init(specItemCraft);
    }

    public void OnGameEvent(RefreshEvent gameEventType)
    {
        if (gameEventType.Type == Enum_RefreshEventType.Item)
        {
            Refresh();
        }
    }
}