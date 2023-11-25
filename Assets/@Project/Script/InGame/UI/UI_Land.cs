using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Land : MonoBehaviour
{
    [SerializeField] private List<UI_LandShopSlot> _uiShopSlot;

    [SerializeField] private Text _txtLevel;
    [SerializeField] private Text _txtExp;
    
    private List<int> _slotList;

    private int _cahcePrice;

    public void Initialize(List<int> slotList)
    {
        _slotList = slotList;

        SetSlot();
    }

    private void SetSlot()
    {
        for (int i = 0; i < _slotList.Count; i++)
        {
            _uiShopSlot[i].Initialize(_slotList[i]);
        }
    }

    private void SavePrice(int price)
    {
        _cahcePrice = price;
    }

    private bool TryBuyLand()
    {
        if (InGameManager.Instance.ConsumeCurrency(Enum_Currency.Gold, _cahcePrice))
        {
            return true;
        }

        return false;
    }

    public void OnClickLevelUp()
    {
        if (InGameManager.Instance.LandSystem.TryExpUp())
        {
            
        }
    }

    public void OnClickReload()
    {
        if (InGameManager.Instance.LandSystem.ReloadShop())
        {
            
        }
    }

    public void OnClickNextStep()
    {
        InGameManager.Instance.HandleRewardStart();
    }
}