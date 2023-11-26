using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Land : UI_Base
{
    [SerializeField] private List<UI_LandShopSlot> _uiShopSlot;

    [SerializeField] private TextMeshProUGUI _txtLevel;
    [SerializeField] private TextMeshProUGUI _txtExp;
    
    private List<int> _slotList;

    private int _cahcePrice;

    public void Initialize(List<int> slotList)
    {
        _slotList = slotList;

        SetSlot();
        Refresh();
        
        gameObject.SetActive(true);
        Open();
    }

    private void SetSlot()
    {
        for (int i = 0; i < _slotList.Count; i++)
        {
            _uiShopSlot[i].Initialize(_slotList[i]);
        }
    }

    public void Refresh()
    {
        _txtLevel.text = $"Lv.{InGameManager.Instance.LandSystem.Level}";
        _txtExp.text = $"Lv.{InGameManager.Instance.LandSystem.Exp}";
    }

    private void SavePrice(int price)
    {
        _cahcePrice = price;
    }

    private bool TryBuyLand()
    {
        if (InGameManager.Instance.TryConsumeCurrency(Enum_Currency.Gold, _cahcePrice))
        {
            return true;
        }

        return false;
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