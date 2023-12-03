using System.Collections;
using System.Collections.Generic;
using EnhancedUI.EnhancedScroller;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_SpecItemSlot : MonoBehaviour
{
    [SerializeField] private Image _imgBG;
    [SerializeField] private Image _imgItem;
    [SerializeField] private TextMeshProUGUI _textAmount;

    private SpecItem _item;

    public void Init(SpecItem specItem)
    {
        if (specItem == null)
        {
            gameObject.SetActive(false);
            return;
        }
        
        _item = specItem;

        _imgBG.color = ColorExtension.GradeColor[_item.level];
        _imgItem.sprite = ResourceManager.Instance.GetIconSprite(Enum_IconType.Item, _item.itemId);

        gameObject.SetActive(true);
    }

    public UI_SpecItemSlot SetAmount(int amount)
    {
        if (amount < 1)
        {
            _textAmount.gameObject.SetActive(false);
            return this;
        }
        
        _textAmount.text = $"{amount}";
        _textAmount.gameObject.SetActive(true);
        
        return this;
    }
}
