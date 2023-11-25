
public enum Enum_RewardType
{
    Currency,
    Land,
}

public class Reward
{
    public Enum_RewardType RewardType;
    public int Index;
    public int Amount;

    public Reward(Enum_RewardType type, int index, int amount)
    {
        RewardType = type;
        Index = index;
        Amount = amount;
    }
}