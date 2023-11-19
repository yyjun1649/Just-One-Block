public class SpecItem
{
    public int itemId;
    public Enum_ItemType itemType;
    public Enum_ResourceType ResourceType;
    public int level;

    public SpecItem(int itemId, Enum_ItemType itemType, Enum_ResourceType resourceType, int level)
    {
        this.itemId = itemId;
        this.itemType = itemType;
        ResourceType = resourceType;
        this.level = level;
    }
}