using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LandSystem : PlaySystem
{
    [SerializeField] private List<Block> _blocks;
    [SerializeField] private UI_Land _uiLand;

    private List<(int,bool)> _cacheblock = new List<(int,bool)>();
    private int _level;

    public override void Initialize()
    {
        _cacheblock.Clear();
        for (int i = _cacheblock.Count; i < _blocks.Count; i++)
        {
            _cacheblock.Add((i,false));
        }
    }

    public void ShowUI()
    {
        _uiLand.Initialize();
    }

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

    public void BuyLand(int i)
    {
        
    }

    private void GetRandomLand()
    {
        for (int i = 0; i < 3; i++)
        {
        }
    }

    private void GetRandomPos()
    {
        var enableLand = _cacheblock.FindAll(x => x.Item2 == false);
        var randLand = Random.Range(0, enableLand.Count);
    }
}
