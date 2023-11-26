using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Land : UI_Base
{
    [SerializeField] private List<UI_LandShopSlot> _uiShopSlot;

    [SerializeField] private TextMeshProUGUI _txtLevel;
    [SerializeField] private TextMeshProUGUI _txtExp;

    [SerializeField] private Image _imgFillExp;

    private List<int> _slotList;

    private int _cahcePrice;

    public void Initialize(List<int> slotList)
    {
        _slotList = slotList;

        SetSlot();
        Refresh();
        
        Open();
    }

    private void SetSlot()
    {
        for (int i = 0; i < _slotList.Count; i++)
        {
            _uiShopSlot[i].Initialize(_slotList[i],i);
        }
    }
    
    public void Refresh()
    {
        var level = InGameManager.Instance.LandSystem.Level;
        var exp = InGameManager.Instance.LandSystem.Exp;
        var totalExp = SpecDataManager.Instance.SpecShopLevelData[level];
        
        _txtLevel.text = $"Lv.{level}";
        _txtExp.text = $"{exp.Amount}/{totalExp.requiredExp}";

        _imgFillExp.fillAmount = (float)exp.Amount / totalExp.requiredExp;
    }

    public void OnClickLevelUp()
    {
        if (InGameManager.Instance.LandSystem.TryExpUp())
        {
            Refresh();
        }
    }

    public void OnClickReload()
    {
        if (InGameManager.Instance.LandSystem.ReloadShop())
        {
            Refresh();
        }
    }
}