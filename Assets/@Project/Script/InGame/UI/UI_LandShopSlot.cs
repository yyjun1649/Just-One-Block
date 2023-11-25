using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_LandShopSlot : MonoBehaviour
{
    [SerializeField] private DragAndDrop _dragAndDrop;

    private int _landId = 3;
    private SpecLandData _specLandData;
    
    public void Initialize(int landId)
    {
        _landId = landId;
        _specLandData = SpecDataManager.Instance.SpecLandData[landId];
    }
    
    public void OnMouseDown()
    {
        if (!InGameManager.Instance.IsEnoughCurrency(Enum_Currency.Gold, _specLandData.price))
        {
            return;
        }
        
        DragAndDropHandler.Grap(_landId);
        _dragAndDrop.OnDrag(_landId);
    }

    public void OnMouseUp()
    {
        _dragAndDrop.OnEndDrag();
    }
}
