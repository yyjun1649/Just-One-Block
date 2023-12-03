using UnityEngine;

public class UI_Inventory : UI_Base, GameEventListener<RefreshEvent>
{
    [SerializeField] private UI_InventoryScroller _scroller;
    
    public void Initialize()
    {
        this.AddGameEventListening<RefreshEvent>();
        
        Open();
        
        Refresh();
    }

    public void Refresh()
    {
        var items = InGameManager.Instance.InventorySystem.GetExistItem();

        _scroller.Initialize(items);
    }

    public void OnGameEvent(RefreshEvent gameEventType)
    {
        if (gameEventType.Type == Enum_RefreshEventType.Item)
        {
            Refresh();
        }
    }
}
