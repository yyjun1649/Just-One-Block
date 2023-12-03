public class UI_InventoryScroller : UI_EnhancedScroller<UI_InventorySlot,Item>
{
    protected override void RefreshCellView(UI_InventorySlot cellView, Item data)
    {
        cellView.Init(data);
    }
}