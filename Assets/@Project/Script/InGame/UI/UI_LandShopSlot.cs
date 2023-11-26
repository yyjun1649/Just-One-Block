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

    private int _slotIndex;
    private int _landId;
    private SpecLandData _specLandData;
    
    public void Initialize(int landId, int slotIndex)
    {
        _landId = landId;
        _slotIndex = slotIndex;

        if (landId >= 0)
        {
            _specLandData = SpecDataManager.Instance.SpecLandData[_landId];
        }

        Refresh();
    }

    public void Refresh()
    {
        var isEnableLand = _landId >= 0;
        _imgLand.sprite = ResourceManager.Instance.GetIconSprite(Enum_IconType.Land, _landId);
        _txtLandPrice.text = $"{_specLandData?.price}";
        _imgLand.gameObject.SetActive(isEnableLand);
        _txtLandPrice.gameObject.SetActive(isEnableLand);
    }
    
    public void OnMouseDown()
    {
        if (_landId < 0)
        {
            return;
        }
        
        if (!InGameManager.Instance.IsEnoughCurrency(Enum_Currency.Gold, _specLandData.price))
        {
            return;
        }
        
        DragAndDropHandler.Grap(_landId,_slotIndex);
        _dragAndDrop.OnDrag(_landId);
    }

    public void OnMouseUp()
    {
        _dragAndDrop.OnEndDrag();
    }
}
