public static class DragAndDropHandler
{
    public static int GrapIndex;
    public static int SlotIndex;
    private static SpecLandData grapSpec;

    public static void Grap(int id, int slotIndex)
    {
        GrapIndex = id;
        SlotIndex = slotIndex;
        grapSpec = SpecDataManager.Instance.SpecLandData[id];
    }

    public static int GetPrice()
    {
        return grapSpec.price;
    }

    public static int Drop()
    {
        var dropid = GrapIndex;

        GrapIndex = -1;
        grapSpec = null;

        return dropid;
    }
}
