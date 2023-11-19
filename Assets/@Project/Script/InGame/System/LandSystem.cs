
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class LandSystem : PlaySystem
{
    [SerializeField] private List<Land> _blocks;
    [SerializeField] private UI_Land _uiLand;

    private List<(int, bool)> _cacheblock = new List<(int, bool)>();

    private List<int> _shopSlot = new List<int>();

    private int _level;
    private Currency _exp;

    public int Level => _level;
    public Currency Exp => _exp;

    public SpecShopProb CacheProb;

    public override void Initialize()
    {
        _cacheblock.Clear();
        for (int i = _cacheblock.Count; i < _blocks.Count; i++)
        {
            _cacheblock.Add((i, false));
        }
        
        GetSpecShopProb();
        GetRandomLand();
    }

    public void ShowUI()
    {
        GetRandomLand();
        _uiLand.Initialize();
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
            if (block == null || block.BlockType == Enum_BlockType.None)
            {
                continue;
            }

            block.GetReward();
        }
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
}
