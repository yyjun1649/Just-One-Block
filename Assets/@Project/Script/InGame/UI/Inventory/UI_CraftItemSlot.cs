using System.Collections;
using System.Collections.Generic;
using EnhancedUI.EnhancedScroller;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_CraftItemSlot : MonoBehaviour
{
    [SerializeField] private Image _imgBG;
    [SerializeField] private Image _imgItem;
    [SerializeField] private TextMeshProUGUI _textAmount;

    private Item _item;

    public void Init(int id, int enoughAmount)
    {
        _item = InGameManager.Instance.InventorySystem.Items[id];

        _textAmount.text = $"{_item.Amount}";

        _imgItem.sprite = ResourceManager.Instance.GetIconSprite(Enum_IconType.Item, id);
        
        if (_item == null || _item.Amount < enoughAmount)
        {
            _imgBG.color = Color.red;
            _textAmount.color = Color.red;
        }
        else
        {
            _imgBG.color = ColorExtension.GradeColor[_item.Spec.level];
            _textAmount.color = Color.white;
        }

        gameObject.SetActive(true);
    }
}
