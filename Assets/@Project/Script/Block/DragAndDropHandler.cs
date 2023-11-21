public static class DragAndDropHandler
{
    public static int GrapObject;

    public static void Grap(int id)
    {
        GrapObject = id;
    }

    public static int Drop()
    {
        return GrapObject;
    }
}
