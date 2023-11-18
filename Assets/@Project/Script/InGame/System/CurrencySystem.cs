using System;
using System.Collections.Generic;
using UnityEngine;

public class CurrencySystem : PlaySystem
{
    [SerializeField] private UI_Currency _uiCurrency;
    private List<int> _currency = new List<int>();

    public override void Initialize()
    {
        for (int i = _currency.Count; i < (int)Enum_Currency.Count; i ++)
        {
            _currency.Add(0);
        }

        _currency[(int)Enum_Currency.Gold] = 5;
    }
    
    public void SetUI(params Enum_Currency[] currencies)
    {
        _uiCurrency.SetUI(currencies);
    }
}
