using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_LandShopSlot : MonoBehaviour
{
    [SerializeField] private Image _imgLand;
    [SerializeField] private TextMeshProUGUI _txtLandPrice;
    [SerializeField] private DragAndDrop _dragAndDrop;

    private int _landId = 3;
    private SpecLandData _specLandData;
    
    public void Initialize(int landId)
    {
        _landId = landId;
        _specLandData = SpecDataManager.Instance.SpecLandData[landId];
    }

    public void Refresh()
    {
        _imgLand.sprite = ResourceManager.Instance.GetIconSprite(Enum_IconType.Land, _landId);
        _txtLandPrice.text = $"{_specLandData.price}";
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
