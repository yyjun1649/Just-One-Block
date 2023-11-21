using System;
using UnityEngine;

public class Land : MonoBehaviour
{
    public Enum_BlockType BlockType;
    private SpecLandData _specLandData;
    private int _slotIndex = -1;
    private int _id = -1;

    public void Initialize(int id,int slotIndex)
    {
        _slotIndex = slotIndex;

        if (id >= 0)
        {
            _specLandData = SpecDataManager.Instance.SpecLandData[id];
        }
    }

    public void SellLand()
    {
        _id = -1;
    }

    public void GetReward()
    {
        if (_id < 0)
        {
            return;
        }
        
        var type =_specLandData.itemType;
    }

    public void OnClickBlock()
    {
        if (_id < 0)
        {
            return;
        }
    }
}
