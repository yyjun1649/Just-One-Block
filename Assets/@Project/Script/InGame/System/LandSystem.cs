
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using Random = UnityEngine.Random;

public class LandSystem : PlaySystem
{
    [SerializeField] private List<LandSet> _blocks;
    [SerializeField] private UI_Land _uiLand;

    private List<int> _shopSlot = new List<int>();

    private int _level;
    private Currency _exp;

    public int Level => _level;
    public Currency Exp => _exp;

    public SpecShopProb CacheProb;

    public override void Initialize()
    {
        var count = _blocks.Count;
        
        for (int i = 0; i < count; i++)
        {
            _blocks[i].Initialize(i);
        }

        var center = count / 2;
        
        _blocks[center].Lands[center].SetBlock(0);
        _blocks[center].Lands[center].SetLock(true);
        
        GetSpecShopProb();
    }

    public void ShowUI()
    {
        GetRandomLand();
        _uiLand.Initialize(_shopSlot);
    }
    
    #region Event
    
    public bool TryExpUp()
    {
        if (!IsEnableLevelUp())
        {
            return false;
        }

        if (InGameManager.Instance.ConsumeCurrency(Enum_Currency.Gold, 4))
        {
            return false;
        }

        _exp.Add(4);

        if (TryLevelUp())
        {
            
        }
        
        return true;
    }

    public bool ReloadShop()
    {
        if (!IsEnableReload())
        {
            return false;
        }
        
        ShowUI();
        return true;
    }

    #endregion

    public void CalculateLand()
    {
        foreach (var block in _blocks)
        {
            block.RewardStackPush();
        }
        
        RewardManager.StackConsume();
    }

    private void GetSpecShopProb()
    {
        CacheProb = SpecDataManager.Instance.SpecShopProbData[_level];
    }

    private void GetRandomLand()
    {
        var probList = CacheProb.prob;

        for (int i = 0; i < 3; i++)
        {
            var grade = UtilCode.GetWeightChance(probList);
            var landData = SpecDataManager.Instance.SpecLandData;
            var pickLand = ListPool<SpecLandData>.Get();

            foreach (var land in landData)
            {
                if (land.level == grade)
                {
                    pickLand.Add(land);
                }
            }

            var randomland = pickLand[Random.Range(0, pickLand.Count)];

            _shopSlot[i] = randomland.fieldID;
            
            ListPool<SpecLandData>.Release(pickLand);
        }
    }

    private bool TryLevelUp()
    {
        var specData = SpecDataManager.Instance.SpecShopLevelData[_level];

        if (!_exp.TryConsume(specData.requiredExp))
        {
            return false;
        }

        _level++;
        GetSpecShopProb();
        
        return true;
    }

    public bool IsEnableLevelUp()
    {
        if (_level > SpecDataManager.Instance.SpecShopProbData.Count - 1)
        {
            return false;
        }

        return true;
    }
    
    public bool IsEnableReload()
    {
        if (!InGameManager.Instance.IsEnoughCurrency(Enum_Currency.Gold,2))
        {
            return false;
        }

        return true;
    }
    
    public bool IsEnableDrop(int id)
    {
        if (id < 0)
        {
            return true;
        }

        return false;
    }
}
