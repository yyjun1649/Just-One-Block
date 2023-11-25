using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_LandShopSlot : MonoBehaviour
{
    [SerializeField] private DragAndDrop _dragAndDrop;

    private int _landId = 3;
    
    public void Initialize(int landId)
    {
        _landId = landId;
    }
    
    public void OnMouseDown()
    {
        DragAndDropHandler.Grap(_landId);
        _dragAndDrop.OnDrag(_landId);
    }

    public void OnMouseUp()
    {
        _dragAndDrop.OnEndDrag();
    }
}
