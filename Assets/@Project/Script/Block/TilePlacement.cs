using UnityEngine;
using UnityEngine.EventSystems;

public class TilePlacement : MonoBehaviour, IDropHandler
{
    private Vector2 originalPosition;
    private GameObject _gameObject;
    
    private bool IsValidPlacement()
    {
        return _gameObject == null;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (IsValidPlacement())
        {
            _gameObject = DragAndDropHandler.GrapObject;
            DragAndDropHandler.Drop(this.transform.position);
        }
        else
        {
            DragAndDropHandler.Retrun();
        }
    }
}