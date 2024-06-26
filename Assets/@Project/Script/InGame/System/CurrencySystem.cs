﻿using System;
using System.Collections.Generic;
using Unity.VisualScripting;
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
            _currency[i].Initialize((Enum_Currency)i);
        }
        
        _currency[(int)Enum_Currency.Gold].Add(999);
    }
    
    public void SetUI(params Enum_Currency[] currencies)
    {
        _uiCurrency.SetUI(currencies);
    }

    public void AddCurrency(Enum_Currency currency, int amount)
    {
        _currency[(int)currency].Add(amount);
        
        CurrencyEvent.Trigger(Enum_Currency.Blood);
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
            CurrencyEvent.Trigger(Enum_Currency.Blood);
            return true;
        }

        return false;
    }

    public int GetCurrencyAmount(Enum_Currency currency)
    {
        if (currency == Enum_Currency.None)
        {
            return 0;
        }
        
        return _currency[(int)currency].Amount;
    }
}
