using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_LandShopSlot : MonoBehaviour
{
    [SerializeField] private DragAndDrop _dragAndDrop;

    private int _landId;
    
    public void Initialize(int landId)
    {
        _landId = landId;
    }
    
    public void OnMouseDown()
    {
        DragAndDropHandler.Grap(_landId);
        _dragAndDrop.OnDrag();
    }

    public void OnMouseUp()
    {
        _dragAndDrop.OnEndDrag();
    }
}
