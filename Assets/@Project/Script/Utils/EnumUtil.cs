using System;

public static class EnumUtil
{
    public static Enum_Currency ConvertToCurrencyType(Enum_RewardType rewardType, int rewardIndex = 0)
    {
        if (rewardType == Enum_RewardType.Currency)
        {
            return (Enum_Currency)rewardIndex;
        }
        
        if (!Enum.TryParse(rewardType.ToString(), out Enum_Currency currencyType))
        {
            return Enum_Currency.None;
        }

        return currencyType;
    }
}