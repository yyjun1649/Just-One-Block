using System;
using System.Collections.Generic;
using UnityEngine;

public class CurrencySystem : PlaySystem
{
    [SerializeField] private UI_Currency _uiCurrency;
    private List<Currency> _currency = new List<Currency>();

    public override void Initialize()
    {
        for (int i = _currency.Count; i < (int)Enum_Currency.Count; i ++)
        {
            _currency.Add(new Currency());
        }

        _currency[(int)Enum_Currency.Gold].Add(5);
    }
    
    public void SetUI(params Enum_Currency[] currencies)
    {
        _uiCurrency.SetUI(currencies);
    }

    public bool IsEnough(Enum_Currency currencyType, int count)
    {
        if (!_currency[(int)currencyType].IsEnough(count))
        {
            return false;
        }

        return true;
    }
    
    public bool TryConsume(Enum_Currency currencyType, int count)
    {
        if (_currency[(int)currencyType].TryConsume(count))
        {
            return true;
        }

        return false;
    }
}
