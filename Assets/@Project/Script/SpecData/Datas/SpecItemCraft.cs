using System.Collections.Generic;

public class SpecItemCraft
{
    public int itemId;
    public List<int> resourceItemId;
    public List<int> resourceCount;

    public SpecItemCraft(int itemId, List<int> resourceItemId, List<int> resourceCount)
    {
        this.itemId = itemId;
        this.resourceItemId = resourceItemId;
        this.resourceCount = resourceCount;
    }
    
    public bool IsHaveResource()
    {
        var items = InGameManager.Instance.InventorySystem.Items;
        bool isEnable = false;

        for (int i = 0; i < resourceItemId.Count; i++)
        {
            var id = resourceItemId[i];

            var item = items[id];

            if (item.Amount > 0)
            {
                isEnable = true;
            }
        }

        return isEnable;
    }
}
