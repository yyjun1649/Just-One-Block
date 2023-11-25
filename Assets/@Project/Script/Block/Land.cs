using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Land : MonoBehaviour, IDropHandler
{
    [SerializeField] private SpriteRenderer _spriteLand;
    
    private SpecLandData _specLandData;
    public int LandID = -1;
    public LandPos LandPos = new LandPos();
    
    public void Initialize(int id,int x, int y)
    {
        LandPos.SetPos(x,y);

        if (id >= 0)
        {
            _specLandData = SpecDataManager.Instance.SpecLandData[id];
        }

        Refresh();
    }

    private void SetBlock(int id)
    {
        LandID = id;
        _specLandData = SpecDataManager.Instance.SpecLandData[id];
        
        Refresh();
    }

    public void Refresh()
    {
        _spriteLand.sprite = ResourceManager.Instance.GetIconSprite(Enum_IconType.Land, LandID);
    }

    public void SellLand()
    {
        LandID = -1;
    }

    public Reward GetReward()
    {
        if (LandID < 0)
        {
            return null;
        }
        
        var type =_specLandData.itemType;

        return new Reward();
    }

    public void OnClickBlock()
    {
        if (LandID < 0)
        {
            return;
        }
    }

    public bool IsEnableDrop()
    {
        if (LandID < 0)
        {
            return true;
        }

        return false;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (IsEnableDrop())
        {
            SetBlock(DragAndDropHandler.Drop());
        }
    }
}
