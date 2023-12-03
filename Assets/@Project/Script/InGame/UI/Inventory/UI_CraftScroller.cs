using System;

public class UI_CraftScroller : UI_EnhancedScroller<UI_CraftSlot,SpecItemCraft>
{
    private Action<SpecItemCraft> _action;
    
    public void SetAction(Action<SpecItemCraft> action)
    {
        _action = action;
    }
    
    protected override void RefreshCellView(UI_CraftSlot cellView, SpecItemCraft data)
    {
        cellView.Init(data,_action);
    }
}
