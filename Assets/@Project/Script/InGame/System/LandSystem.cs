
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
    private Currency _exp = new Currency();

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

        for (int i = 0; i < 3; i++)
        {
            _shopSlot.Add(-1);
        }

        var center = count / 2;
        
        _blocks[center].Lands[center].SetBlock(0);
        _blocks[center].Lands[center].SetLock(true);
        
        ShowOffUI();
        
        GetSpecShopProb();
    }

    public void RefreshLand()
    {
        for (int i = 0; i < _blocks.Count; i++)
        {
            var blockSet = _blocks[i];
            
            blockSet.SetLandOn();
        }
        
        for (int i = 0; i < _blocks.Count; i++)
        {
            var blockSet = _blocks[i];
            
            var OnLand = blockSet.GetLandOn();

            for (int j = 0; j < OnLand.Count; j++)
            {
                var landOn = OnLand[j];
                
                if (i > 0)
                {
                    _blocks[i-1].Lands[landOn].SetActive(true);
                }
            
                if (i < _blocks.Count-1)
                {
                    _blocks[i+1].Lands[landOn].SetActive(true);
                }
            }
        }
    }
    public void ShowUI()
    {
        GetRandomLand();
        _uiLand.Initialize(_shopSlot);
    }

    public void BuyAction(int index)
    {
        _shopSlot[index] = -1;
        _uiLand.Initialize(_shopSlot);
    }

    public void ShowOffUI()
    {
        _uiLand.Close();
    }

    #region Event
    
    public bool TryExpUp()
    {
        if (!IsEnableLevelUp())
        {
            return false;
        }

        if (!InGameManager.Instance.TryConsumeCurrency(Enum_Currency.Gold, 4))
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
        if (!TryReload())
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
    public bool TryReload()
    {
        if (!InGameManager.Instance.TryConsumeCurrency(Enum_Currency.Gold,2))
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
