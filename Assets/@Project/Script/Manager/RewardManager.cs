﻿using System.Collections.Generic;

public static class RewardManager
{
    private static List<Reward> _rewardSave = new List<Reward>();
    
    public static void PushReward(Reward reward)
    {
        var targetReward = _rewardSave.Find(x => x.RewardType == reward.RewardType && x.Index == reward.Index);

        if (targetReward == null)
        {
            _rewardSave.Add(reward);
        }
        else
        {
            targetReward.Amount += reward.Amount;
        }
    }

    public static void StackClear()
    {
        _rewardSave.Clear();
    }

    public static void StackConsume()
    {
        TryConsume(_rewardSave);
        
        StackClear();
    }

    public static void TryConsume(Reward reward)
    {
        Consume(reward);
    }
    
    public static void TryConsume(List<Reward> rewards)
    {
        foreach (var reward in rewards)
        {
            Consume(reward);
        }
    }

    public static void Consume(Reward reward)
    {
        var index = reward.Index;
        var type = reward.RewardType;
        var amount = reward.Amount;

        if (index < 0 || amount < 0)
        {
            return;
        }
        
        switch (type)
        {
            case Enum_RewardType.Land:
                InGameManager.Instance.InventorySystem.AddItem(index,amount);
                break;
            default:
                var currencyType = EnumUtil.ConvertToCurrencyType(reward.RewardType);

                if (currencyType != Enum_Currency.None)
                {
                    InGameManager.Instance.CurrencySystem.AddCurrency(currencyType,amount);
                    break;
                }

                break;
        }
    }
}
