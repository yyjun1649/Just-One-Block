using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandSystem : MonoBehaviour
{
    private List<Block> _blocks = new List<Block>();
    [SerializeField] private UI_Land _uiLand;

    public void ShowUI()
    {
        _uiLand.Initialize();
    }

    public void CalculateLand()
    {
        
    }

    public void BuyLand()
    {
        
    }

    private void GetRandomLand()
    {
        
    }
}
