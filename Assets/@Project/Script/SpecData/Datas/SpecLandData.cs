using System.Collections.Generic;

public class SpecLandData
{
    public int fieldID;
    public int level;
    public int price;
    public Enum_ResourceType itemType;
    
    private Reward _reward;
    public SpecLandData(int id, int le, int pr, Enum_ResourceType type)
    {
        fieldID = id;
        level = le;
        price = pr;
        itemType = type;
    }

    public Reward GetReward()
    {
        return new Reward(Enum_RewardType.Land, fieldID, 1);;
    }
}