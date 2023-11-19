using System;
using UnityEngine;

public class Land : MonoBehaviour
{
    public Enum_BlockType BlockType;
    private SpecLandData _specLandData;
    private int _slotIndex = -1;

    public void Initialize(int id,int slotIndex)
    {
        _slotIndex = slotIndex;
        _specLandData = SpecDataManager.Instance.SpecLandData[id];
    }

    public void SellLand()
    {
        _slotIndex = -1;
    }

    public void GetReward()
    {
        if (_slotIndex < 0)
        {
            return;
        }
        
        var type =_specLandData.itemType;
    }

    public void OnClickBlock()
    {
        if (_slotIndex < 0)
        {
            return;
        }
    }
}
