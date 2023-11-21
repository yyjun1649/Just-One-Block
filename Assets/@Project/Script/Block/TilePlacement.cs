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
        
    }
}