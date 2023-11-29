using System.Collections.Generic;

public class SpecDataManager : SingletonBehaviour<SpecDataManager>
{
    public List<SpecLandData> SpecLandData = new List<SpecLandData>();
    public List<SpecItem> SpecItemData = new List<SpecItem>();
    public List<SpecItemCraft> SpecItemCraftData = new List<SpecItemCraft>();
    public List<SpecShopProb> SpecShopProbData = new List<SpecShopProb>();
    public List<SpecLevel> SpecShopLevelData = new List<SpecLevel>();
    public List<SpecWeapon> SpecWeaponData = new List<SpecWeapon>();
    public List<SpecProjectile> SpecProjectileData = new List<SpecProjectile>();
    
    private void Start()
    {
        ParseSpecLand();
        ParseSpecItemCraft();
        ParseSpecShopProb();
        ParseSpecItem();
        ParseSpecLevel();
    }

    #region Parse

    private void ParseSpecLevel()
    {
        BGSpecLevel.ForEachEntity(
            x =>
            {
                SpecLevel data = new SpecLevel(
                    x.level,
                    x.requiredExp
                );
                
                SpecShopLevelData.Add(data);
            });
    }
    
    private void ParseSpecLand()
    {
        BGSpecLand.ForEachEntity(
            x =>
            {
                SpecLandData data = new SpecLandData(
                    x.fieldID,
                    x.level,
                    x.price,
                    x.resourceType
                );
                
                SpecLandData.Add(data);
            });
    }
    
    private void ParseSpecShopProb()
    {
        BGSpecShopProb.ForEachEntity(
            x =>
            {
                SpecShopProb data = new SpecShopProb(
                    x.level,
                    x.prob
                    );
                
                SpecShopProbData.Add(data);
            });
    }

    
    private void ParseSpecItem()
    {
        BGSpecItem.ForEachEntity(
            x =>
            {
                SpecItem data = new SpecItem(
                    x.fieldID,
                    x.itemType,
                    x.resourceType,
                    x.level
                );
                
                SpecItemData.Add(data);
            });
    }
    
    private void ParseSpecItemCraft()
    {
        BGSpecItemCraft.ForEachEntity(
            x =>
            {
                SpecItemCraft data = new SpecItemCraft(
                    x.itemId,
                    x.resourceItemId,
                    x.resourceCount
                );
                
                SpecItemCraftData.Add(data);
            });
    }



    #endregion
}