
using UnityEngine;

public static class DragAndDropHandler
{
    public static GameObject GrapObject;

    public static void Grap(GameObject gameObject)
    {
        GrapObject = gameObject;
    }

    public static void Drop(Vector3 pos)
    {
        GrapObject.GetComponent<DragAndDrop>().SetPosition(pos);
        GrapObject = null;
    }

    public static void Retrun()
    {
        GrapObject.GetComponent<DragAndDrop>().ResetPosition();
        GrapObject = null;
        
    }
}
