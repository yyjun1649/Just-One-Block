using System;
using EnhancedUI.EnhancedScroller;
using UnityEngine;
using UnityEngine.UI;

public class UI_CraftSlot : EnhancedScrollerCellView
{
    [SerializeField] private Image _imgBG;
    [SerializeField] private Image _imgWeapon;
    [SerializeField] private CanvasGroup _canvasGroup;

    private Action<SpecItemCraft> _action;
    private SpecItemCraft _spec;
    
    public void Init(SpecItemCraft specCraft, Action<SpecItemCraft> action)
    {
        _spec = specCraft;
        _action = action;
        var weaponSpec = SpecDataManager.Instance.SpecWeaponData[specCraft.itemId];

        _imgBG.color = ColorExtension.GradeColor[weaponSpec.grade];
        _imgWeapon.sprite = ResourceManager.Instance.GetIconSprite(Enum_IconType.Weapon, weaponSpec.fieldID);
        
    }

    public void SetInfoPanel()
    {
        _canvasGroup.alpha = 1f;
        _action?.Invoke(_spec);
    }
    
    public void UnSetInfoPanel()
    {
        _canvasGroup.alpha = 0.4f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ScrollerCheck"))
        {
            SetInfoPanel();
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("ScrollerCheck"))
        {
            UnSetInfoPanel();
        }
    }
}
