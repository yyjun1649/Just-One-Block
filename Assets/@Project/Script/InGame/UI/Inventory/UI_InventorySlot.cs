using System.Collections;
using System.Collections.Generic;
using EnhancedUI.EnhancedScroller;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_InventorySlot : EnhancedScrollerCellView
{
    [SerializeField] private Image _imgBG;
    [SerializeField] private Image _imgItem;
    [SerializeField] private TextMeshProUGUI _textAmount;

    private Item _item;

    public void Init(Item item)
    {
        _item = item;
        
        if (item.Amount < 0)
        {
            gameObject.SetActive(false);
            return;
        }
        
        _imgBG.color = ColorExtension.GradeColor[item.Spec.level];
        _imgItem.sprite = ResourceManager.Instance.GetIconSprite(Enum_IconType.Item, item.Spec.itemId);
        _textAmount.text = $"{item.Amount}";
        
        gameObject.SetActive(true);
    }

    public override void RefreshCellView()
    {
        if (_item.Amount < 0)
        {
            gameObject.SetActive(false);
            return;
        }
        
        _textAmount.text = $"{_item.Amount}"; 
    }
}
