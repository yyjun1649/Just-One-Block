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
}
