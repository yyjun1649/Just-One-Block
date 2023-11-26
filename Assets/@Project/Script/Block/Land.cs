using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Land : MonoBehaviour, IDropHandler
{
    [SerializeField] private SpriteRenderer _spriteLand;
    
    private SpecLandData _specLandData;
    public int LandID = -1;
    public LandPos LandPos = new LandPos();

    private bool _lock = false;
    
    public void Initialize(int id,int x, int y)
    {
        LandPos.SetPos(x,y);

        if (id >= 0)
        {
            _specLandData = SpecDataManager.Instance.SpecLandData[id];
        }

        Refresh();
    }

    public void SetBlock(int id)
    {
        LandID = id;
        _specLandData = SpecDataManager.Instance.SpecLandData[id];
        
        Refresh();
    }

    public void SetLock(bool isLock)
    {
        _lock = isLock;
    }

    public void Refresh()
    {
        _spriteLand.sprite = ResourceManager.Instance.GetIconSprite(Enum_IconType.Land, LandID);
    }

    public bool IsEnableSell()
    {
        if (_lock)
        {
            return false;
        }

        return true;
    }

    public void SellLand()
    {
        InGameManager.Instance.CurrencySystem.AddCurrency(Enum_Currency.Gold,_specLandData.price);
        
        LandID = -1;
    }

    public Reward GetReward()
    {
        if (LandID < 0)
        {
            return null;
        }
        
        //TODO : UI ON

        return _specLandData.GetReward();
    }



    #region Event
    public void OnClickBlock()
    {
        if (LandID < 0)
        {
            return;
        }
        
        //TODO : Sell UI ON
    }

    public void OnDrop(PointerEventData eventData)
    {
        var price = DragAndDropHandler.GetPrice();
        var block = DragAndDropHandler.Drop();

        if (InGameManager.Instance.LandSystem.IsEnableDrop(LandID) 
            && InGameManager.Instance.TryConsumeCurrency(Enum_Currency.Gold,price))
        {
            SetBlock(block);
        }
    }

    public void OnClickSell()
    {
        if (!IsEnableSell())
        {
            return;
        }
        
        SellLand();
    }
    #endregion
}
