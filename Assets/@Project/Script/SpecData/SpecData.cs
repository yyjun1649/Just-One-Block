using System;
using System.Collections.Generic;
using BansheeGz.BGDatabase;

//=============================================================
//||                   Generated by BansheeGz Code Generator ||
//=============================================================

#pragma warning disable 414

public partial class BGSpecLand : BGEntity
{

	public class Factory : BGEntity.EntityFactory
	{
		public BGEntity NewEntity(BGMetaEntity meta) => new BGSpecLand(meta);
		public BGEntity NewEntity(BGMetaEntity meta, BGId id) => new BGSpecLand(meta, id);
	}
	private static BansheeGz.BGDatabase.BGMetaRow _metaDefault;
	public static BansheeGz.BGDatabase.BGMetaRow MetaDefault => _metaDefault ?? (_metaDefault = BGCodeGenUtils.GetMeta<BansheeGz.BGDatabase.BGMetaRow>(new BGId(5081359018685436164UL,8494865362691647621UL), () => _metaDefault = null));
	public static BansheeGz.BGDatabase.BGRepoEvents Events => BGRepo.I.Events;
	public static int CountEntities => MetaDefault.CountEntities;
	public System.String name
	{
		get => _name[Index];
		set => _name[Index] = value;
	}
	public System.Int32 fieldID
	{
		get => _fieldID[Index];
		set => _fieldID[Index] = value;
	}
	public System.Int32 level
	{
		get => _level[Index];
		set => _level[Index] = value;
	}
	public System.Int32 price
	{
		get => _price[Index];
		set => _price[Index] = value;
	}
	public Enum_ResourceType resourceType
	{
		get => (Enum_ResourceType) _resourceType.GetStoredValue(Index);
		set => _resourceType.SetStoredValue(Index, (System.Int32) value);
	}
	private static BansheeGz.BGDatabase.BGFieldEntityName _ufle12jhs77_name;
	public static BansheeGz.BGDatabase.BGFieldEntityName _name => _ufle12jhs77_name ?? (_ufle12jhs77_name = BGCodeGenUtils.GetField<BansheeGz.BGDatabase.BGFieldEntityName>(MetaDefault, new BGId(5668225409058791446UL, 1228705417054942890UL), () => _ufle12jhs77_name = null));
	private static BansheeGz.BGDatabase.BGFieldInt _ufle12jhs77_fieldID;
	public static BansheeGz.BGDatabase.BGFieldInt _fieldID => _ufle12jhs77_fieldID ?? (_ufle12jhs77_fieldID = BGCodeGenUtils.GetField<BansheeGz.BGDatabase.BGFieldInt>(MetaDefault, new BGId(5218512016761643817UL, 10756868320094807219UL), () => _ufle12jhs77_fieldID = null));
	private static BansheeGz.BGDatabase.BGFieldInt _ufle12jhs77_level;
	public static BansheeGz.BGDatabase.BGFieldInt _level => _ufle12jhs77_level ?? (_ufle12jhs77_level = BGCodeGenUtils.GetField<BansheeGz.BGDatabase.BGFieldInt>(MetaDefault, new BGId(5461852483637307625UL, 8460619623087856566UL), () => _ufle12jhs77_level = null));
	private static BansheeGz.BGDatabase.BGFieldInt _ufle12jhs77_price;
	public static BansheeGz.BGDatabase.BGFieldInt _price => _ufle12jhs77_price ?? (_ufle12jhs77_price = BGCodeGenUtils.GetField<BansheeGz.BGDatabase.BGFieldInt>(MetaDefault, new BGId(4986549262900422833UL, 12781762602819230599UL), () => _ufle12jhs77_price = null));
	private static BansheeGz.BGDatabase.BGFieldEnum _ufle12jhs77_resourceType;
	public static BansheeGz.BGDatabase.BGFieldEnum _resourceType => _ufle12jhs77_resourceType ?? (_ufle12jhs77_resourceType = BGCodeGenUtils.GetField<BansheeGz.BGDatabase.BGFieldEnum>(MetaDefault, new BGId(5272438107321908594UL, 2006536496268825233UL), () => _ufle12jhs77_resourceType = null));
	private static readonly BGSpecLand.Factory _factory0_PFS = new BGSpecLand.Factory();
	private static readonly BGSpecItem.Factory _factory1_PFS = new BGSpecItem.Factory();
	private static readonly BGSpecItemCraft.Factory _factory2_PFS = new BGSpecItemCraft.Factory();
	private static readonly BGSpecShopProb.Factory _factory3_PFS = new BGSpecShopProb.Factory();
	private static readonly BGSpecLevel.Factory _factory4_PFS = new BGSpecLevel.Factory();
	private static readonly BGSpecWeapon.Factory _factory5_PFS = new BGSpecWeapon.Factory();
	private BGSpecLand() : base(MetaDefault) {}
	private BGSpecLand(BGId id) : base(MetaDefault, id) {}
	private BGSpecLand(BGMetaEntity meta) : base(meta) {}
	private BGSpecLand(BGMetaEntity meta, BGId id) : base(meta, id) {}
	public static BGSpecLand FindEntity(Predicate<BGSpecLand> filter) => BGCodeGenUtils.FindEntity(MetaDefault, filter);
	public static List<BGSpecLand> FindEntities(Predicate<BGSpecLand> filter, List<BGSpecLand> result=null, Comparison<BGSpecLand> sort=null) => BGCodeGenUtils.FindEntities(MetaDefault, filter, result, sort);
	public static void ForEachEntity(Action<BGSpecLand> action, Predicate<BGSpecLand> filter=null, Comparison<BGSpecLand> sort=null) => BGCodeGenUtils.ForEachEntity(MetaDefault, action, filter, sort);
	public static BGSpecLand GetEntity(BGId entityId) => (BGSpecLand) MetaDefault.GetEntity(entityId);
	public static BGSpecLand GetEntity(int index) => (BGSpecLand) MetaDefault[index];
	public static BGSpecLand GetEntity(string entityName) => (BGSpecLand) MetaDefault.GetEntity(entityName);
	public static BGSpecLand NewEntity() => (BGSpecLand) MetaDefault.NewEntity();
	public static BGSpecLand NewEntity(BGId entityId) => (BGSpecLand) MetaDefault.NewEntity(entityId);
	public static BGSpecLand NewEntity(Action<BGSpecLand> callback) => (BGSpecLand) MetaDefault.NewEntity(new BGMetaEntity.NewEntityContext(entity => callback((BGSpecLand)entity)));
}

public partial class BGSpecItem : BGEntity
{

	public class Factory : BGEntity.EntityFactory
	{
		public BGEntity NewEntity(BGMetaEntity meta) => new BGSpecItem(meta);
		public BGEntity NewEntity(BGMetaEntity meta, BGId id) => new BGSpecItem(meta, id);
	}
	private static BansheeGz.BGDatabase.BGMetaRow _metaDefault;
	public static BansheeGz.BGDatabase.BGMetaRow MetaDefault => _metaDefault ?? (_metaDefault = BGCodeGenUtils.GetMeta<BansheeGz.BGDatabase.BGMetaRow>(new BGId(5106990989339787742UL,13892024108955729821UL), () => _metaDefault = null));
	public static BansheeGz.BGDatabase.BGRepoEvents Events => BGRepo.I.Events;
	public static int CountEntities => MetaDefault.CountEntities;
	public System.String name
	{
		get => _name[Index];
		set => _name[Index] = value;
	}
	public System.Int32 fieldID
	{
		get => _fieldID[Index];
		set => _fieldID[Index] = value;
	}
	public Enum_ItemType itemType
	{
		get => (Enum_ItemType) _itemType.GetStoredValue(Index);
		set => _itemType.SetStoredValue(Index, (System.Int32) value);
	}
	public Enum_ResourceType resourceType
	{
		get => (Enum_ResourceType) _resourceType.GetStoredValue(Index);
		set => _resourceType.SetStoredValue(Index, (System.Int32) value);
	}
	public System.Int32 level
	{
		get => _level[Index];
		set => _level[Index] = value;
	}
	private static BansheeGz.BGDatabase.BGFieldEntityName _ufle12jhs77_name;
	public static BansheeGz.BGDatabase.BGFieldEntityName _name => _ufle12jhs77_name ?? (_ufle12jhs77_name = BGCodeGenUtils.GetField<BansheeGz.BGDatabase.BGFieldEntityName>(MetaDefault, new BGId(5238205162916665030UL, 4789159788899513730UL), () => _ufle12jhs77_name = null));
	private static BansheeGz.BGDatabase.BGFieldInt _ufle12jhs77_fieldID;
	public static BansheeGz.BGDatabase.BGFieldInt _fieldID => _ufle12jhs77_fieldID ?? (_ufle12jhs77_fieldID = BGCodeGenUtils.GetField<BansheeGz.BGDatabase.BGFieldInt>(MetaDefault, new BGId(5276378157149772339UL, 4532223139563656343UL), () => _ufle12jhs77_fieldID = null));
	private static BansheeGz.BGDatabase.BGFieldEnum _ufle12jhs77_itemType;
	public static BansheeGz.BGDatabase.BGFieldEnum _itemType => _ufle12jhs77_itemType ?? (_ufle12jhs77_itemType = BGCodeGenUtils.GetField<BansheeGz.BGDatabase.BGFieldEnum>(MetaDefault, new BGId(5744175861879761151UL, 14083592063369401520UL), () => _ufle12jhs77_itemType = null));
	private static BansheeGz.BGDatabase.BGFieldEnum _ufle12jhs77_resourceType;
	public static BansheeGz.BGDatabase.BGFieldEnum _resourceType => _ufle12jhs77_resourceType ?? (_ufle12jhs77_resourceType = BGCodeGenUtils.GetField<BansheeGz.BGDatabase.BGFieldEnum>(MetaDefault, new BGId(5134704263771556356UL, 16694747829844873138UL), () => _ufle12jhs77_resourceType = null));
	private static BansheeGz.BGDatabase.BGFieldInt _ufle12jhs77_level;
	public static BansheeGz.BGDatabase.BGFieldInt _level => _ufle12jhs77_level ?? (_ufle12jhs77_level = BGCodeGenUtils.GetField<BansheeGz.BGDatabase.BGFieldInt>(MetaDefault, new BGId(5264438566644891105UL, 548619298757212342UL), () => _ufle12jhs77_level = null));
	private static readonly BGSpecLand.Factory _factory0_PFS = new BGSpecLand.Factory();
	private static readonly BGSpecItem.Factory _factory1_PFS = new BGSpecItem.Factory();
	private static readonly BGSpecItemCraft.Factory _factory2_PFS = new BGSpecItemCraft.Factory();
	private static readonly BGSpecShopProb.Factory _factory3_PFS = new BGSpecShopProb.Factory();
	private static readonly BGSpecLevel.Factory _factory4_PFS = new BGSpecLevel.Factory();
	private static readonly BGSpecWeapon.Factory _factory5_PFS = new BGSpecWeapon.Factory();
	private BGSpecItem() : base(MetaDefault) {}
	private BGSpecItem(BGId id) : base(MetaDefault, id) {}
	private BGSpecItem(BGMetaEntity meta) : base(meta) {}
	private BGSpecItem(BGMetaEntity meta, BGId id) : base(meta, id) {}
	public static BGSpecItem FindEntity(Predicate<BGSpecItem> filter) => BGCodeGenUtils.FindEntity(MetaDefault, filter);
	public static List<BGSpecItem> FindEntities(Predicate<BGSpecItem> filter, List<BGSpecItem> result=null, Comparison<BGSpecItem> sort=null) => BGCodeGenUtils.FindEntities(MetaDefault, filter, result, sort);
	public static void ForEachEntity(Action<BGSpecItem> action, Predicate<BGSpecItem> filter=null, Comparison<BGSpecItem> sort=null) => BGCodeGenUtils.ForEachEntity(MetaDefault, action, filter, sort);
	public static BGSpecItem GetEntity(BGId entityId) => (BGSpecItem) MetaDefault.GetEntity(entityId);
	public static BGSpecItem GetEntity(int index) => (BGSpecItem) MetaDefault[index];
	public static BGSpecItem GetEntity(string entityName) => (BGSpecItem) MetaDefault.GetEntity(entityName);
	public static BGSpecItem NewEntity() => (BGSpecItem) MetaDefault.NewEntity();
	public static BGSpecItem NewEntity(BGId entityId) => (BGSpecItem) MetaDefault.NewEntity(entityId);
	public static BGSpecItem NewEntity(Action<BGSpecItem> callback) => (BGSpecItem) MetaDefault.NewEntity(new BGMetaEntity.NewEntityContext(entity => callback((BGSpecItem)entity)));
}

public partial class BGSpecItemCraft : BGEntity
{

	public class Factory : BGEntity.EntityFactory
	{
		public BGEntity NewEntity(BGMetaEntity meta) => new BGSpecItemCraft(meta);
		public BGEntity NewEntity(BGMetaEntity meta, BGId id) => new BGSpecItemCraft(meta, id);
	}
	private static BansheeGz.BGDatabase.BGMetaRow _metaDefault;
	public static BansheeGz.BGDatabase.BGMetaRow MetaDefault => _metaDefault ?? (_metaDefault = BGCodeGenUtils.GetMeta<BansheeGz.BGDatabase.BGMetaRow>(new BGId(5202912179311276183UL,13087323992594095755UL), () => _metaDefault = null));
	public static BansheeGz.BGDatabase.BGRepoEvents Events => BGRepo.I.Events;
	public static int CountEntities => MetaDefault.CountEntities;
	public System.String name
	{
		get => _name[Index];
		set => _name[Index] = value;
	}
	public System.Int32 itemId
	{
		get => _itemId[Index];
		set => _itemId[Index] = value;
	}
	public System.Collections.Generic.List<System.Int32> resourceItemId
	{
		get => _resourceItemId[Index];
		set => _resourceItemId[Index] = value;
	}
	public System.Collections.Generic.List<System.Int32> resourceCount
	{
		get => _resourceCount[Index];
		set => _resourceCount[Index] = value;
	}
	private static BansheeGz.BGDatabase.BGFieldEntityName _ufle12jhs77_name;
	public static BansheeGz.BGDatabase.BGFieldEntityName _name => _ufle12jhs77_name ?? (_ufle12jhs77_name = BGCodeGenUtils.GetField<BansheeGz.BGDatabase.BGFieldEntityName>(MetaDefault, new BGId(5260927904491101007UL, 4584196162846087855UL), () => _ufle12jhs77_name = null));
	private static BansheeGz.BGDatabase.BGFieldInt _ufle12jhs77_itemId;
	public static BansheeGz.BGDatabase.BGFieldInt _itemId => _ufle12jhs77_itemId ?? (_ufle12jhs77_itemId = BGCodeGenUtils.GetField<BansheeGz.BGDatabase.BGFieldInt>(MetaDefault, new BGId(5243397974870845371UL, 920441019561316227UL), () => _ufle12jhs77_itemId = null));
	private static BansheeGz.BGDatabase.BGFieldListInt _ufle12jhs77_resourceItemId;
	public static BansheeGz.BGDatabase.BGFieldListInt _resourceItemId => _ufle12jhs77_resourceItemId ?? (_ufle12jhs77_resourceItemId = BGCodeGenUtils.GetField<BansheeGz.BGDatabase.BGFieldListInt>(MetaDefault, new BGId(5718001340930826029UL, 14713513828212843919UL), () => _ufle12jhs77_resourceItemId = null));
	private static BansheeGz.BGDatabase.BGFieldListInt _ufle12jhs77_resourceCount;
	public static BansheeGz.BGDatabase.BGFieldListInt _resourceCount => _ufle12jhs77_resourceCount ?? (_ufle12jhs77_resourceCount = BGCodeGenUtils.GetField<BansheeGz.BGDatabase.BGFieldListInt>(MetaDefault, new BGId(5055768874375956265UL, 13957518163622810030UL), () => _ufle12jhs77_resourceCount = null));
	private static readonly BGSpecLand.Factory _factory0_PFS = new BGSpecLand.Factory();
	private static readonly BGSpecItem.Factory _factory1_PFS = new BGSpecItem.Factory();
	private static readonly BGSpecItemCraft.Factory _factory2_PFS = new BGSpecItemCraft.Factory();
	private static readonly BGSpecShopProb.Factory _factory3_PFS = new BGSpecShopProb.Factory();
	private static readonly BGSpecLevel.Factory _factory4_PFS = new BGSpecLevel.Factory();
	private static readonly BGSpecWeapon.Factory _factory5_PFS = new BGSpecWeapon.Factory();
	private BGSpecItemCraft() : base(MetaDefault) {}
	private BGSpecItemCraft(BGId id) : base(MetaDefault, id) {}
	private BGSpecItemCraft(BGMetaEntity meta) : base(meta) {}
	private BGSpecItemCraft(BGMetaEntity meta, BGId id) : base(meta, id) {}
	public static BGSpecItemCraft FindEntity(Predicate<BGSpecItemCraft> filter) => BGCodeGenUtils.FindEntity(MetaDefault, filter);
	public static List<BGSpecItemCraft> FindEntities(Predicate<BGSpecItemCraft> filter, List<BGSpecItemCraft> result=null, Comparison<BGSpecItemCraft> sort=null) => BGCodeGenUtils.FindEntities(MetaDefault, filter, result, sort);
	public static void ForEachEntity(Action<BGSpecItemCraft> action, Predicate<BGSpecItemCraft> filter=null, Comparison<BGSpecItemCraft> sort=null) => BGCodeGenUtils.ForEachEntity(MetaDefault, action, filter, sort);
	public static BGSpecItemCraft GetEntity(BGId entityId) => (BGSpecItemCraft) MetaDefault.GetEntity(entityId);
	public static BGSpecItemCraft GetEntity(int index) => (BGSpecItemCraft) MetaDefault[index];
	public static BGSpecItemCraft GetEntity(string entityName) => (BGSpecItemCraft) MetaDefault.GetEntity(entityName);
	public static BGSpecItemCraft NewEntity() => (BGSpecItemCraft) MetaDefault.NewEntity();
	public static BGSpecItemCraft NewEntity(BGId entityId) => (BGSpecItemCraft) MetaDefault.NewEntity(entityId);
	public static BGSpecItemCraft NewEntity(Action<BGSpecItemCraft> callback) => (BGSpecItemCraft) MetaDefault.NewEntity(new BGMetaEntity.NewEntityContext(entity => callback((BGSpecItemCraft)entity)));
}

public partial class BGSpecShopProb : BGEntity
{

	public class Factory : BGEntity.EntityFactory
	{
		public BGEntity NewEntity(BGMetaEntity meta) => new BGSpecShopProb(meta);
		public BGEntity NewEntity(BGMetaEntity meta, BGId id) => new BGSpecShopProb(meta, id);
	}
	private static BansheeGz.BGDatabase.BGMetaRow _metaDefault;
	public static BansheeGz.BGDatabase.BGMetaRow MetaDefault => _metaDefault ?? (_metaDefault = BGCodeGenUtils.GetMeta<BansheeGz.BGDatabase.BGMetaRow>(new BGId(5635180945077348181UL,1300511783720598153UL), () => _metaDefault = null));
	public static BansheeGz.BGDatabase.BGRepoEvents Events => BGRepo.I.Events;
	public static int CountEntities => MetaDefault.CountEntities;
	public System.String name
	{
		get => _name[Index];
		set => _name[Index] = value;
	}
	public System.Int32 level
	{
		get => _level[Index];
		set => _level[Index] = value;
	}
	public System.Collections.Generic.List<System.Int32> prob
	{
		get => _prob[Index];
		set => _prob[Index] = value;
	}
	private static BansheeGz.BGDatabase.BGFieldEntityName _ufle12jhs77_name;
	public static BansheeGz.BGDatabase.BGFieldEntityName _name => _ufle12jhs77_name ?? (_ufle12jhs77_name = BGCodeGenUtils.GetField<BansheeGz.BGDatabase.BGFieldEntityName>(MetaDefault, new BGId(5247323921777843140UL, 6318828700091311238UL), () => _ufle12jhs77_name = null));
	private static BansheeGz.BGDatabase.BGFieldInt _ufle12jhs77_level;
	public static BansheeGz.BGDatabase.BGFieldInt _level => _ufle12jhs77_level ?? (_ufle12jhs77_level = BGCodeGenUtils.GetField<BansheeGz.BGDatabase.BGFieldInt>(MetaDefault, new BGId(5586751873833756395UL, 11591960021552502446UL), () => _ufle12jhs77_level = null));
	private static BansheeGz.BGDatabase.BGFieldListInt _ufle12jhs77_prob;
	public static BansheeGz.BGDatabase.BGFieldListInt _prob => _ufle12jhs77_prob ?? (_ufle12jhs77_prob = BGCodeGenUtils.GetField<BansheeGz.BGDatabase.BGFieldListInt>(MetaDefault, new BGId(4693231885652222930UL, 2359068637079825800UL), () => _ufle12jhs77_prob = null));
	private static readonly BGSpecLand.Factory _factory0_PFS = new BGSpecLand.Factory();
	private static readonly BGSpecItem.Factory _factory1_PFS = new BGSpecItem.Factory();
	private static readonly BGSpecItemCraft.Factory _factory2_PFS = new BGSpecItemCraft.Factory();
	private static readonly BGSpecShopProb.Factory _factory3_PFS = new BGSpecShopProb.Factory();
	private static readonly BGSpecLevel.Factory _factory4_PFS = new BGSpecLevel.Factory();
	private static readonly BGSpecWeapon.Factory _factory5_PFS = new BGSpecWeapon.Factory();
	private BGSpecShopProb() : base(MetaDefault) {}
	private BGSpecShopProb(BGId id) : base(MetaDefault, id) {}
	private BGSpecShopProb(BGMetaEntity meta) : base(meta) {}
	private BGSpecShopProb(BGMetaEntity meta, BGId id) : base(meta, id) {}
	public static BGSpecShopProb FindEntity(Predicate<BGSpecShopProb> filter) => BGCodeGenUtils.FindEntity(MetaDefault, filter);
	public static List<BGSpecShopProb> FindEntities(Predicate<BGSpecShopProb> filter, List<BGSpecShopProb> result=null, Comparison<BGSpecShopProb> sort=null) => BGCodeGenUtils.FindEntities(MetaDefault, filter, result, sort);
	public static void ForEachEntity(Action<BGSpecShopProb> action, Predicate<BGSpecShopProb> filter=null, Comparison<BGSpecShopProb> sort=null) => BGCodeGenUtils.ForEachEntity(MetaDefault, action, filter, sort);
	public static BGSpecShopProb GetEntity(BGId entityId) => (BGSpecShopProb) MetaDefault.GetEntity(entityId);
	public static BGSpecShopProb GetEntity(int index) => (BGSpecShopProb) MetaDefault[index];
	public static BGSpecShopProb GetEntity(string entityName) => (BGSpecShopProb) MetaDefault.GetEntity(entityName);
	public static BGSpecShopProb NewEntity() => (BGSpecShopProb) MetaDefault.NewEntity();
	public static BGSpecShopProb NewEntity(BGId entityId) => (BGSpecShopProb) MetaDefault.NewEntity(entityId);
	public static BGSpecShopProb NewEntity(Action<BGSpecShopProb> callback) => (BGSpecShopProb) MetaDefault.NewEntity(new BGMetaEntity.NewEntityContext(entity => callback((BGSpecShopProb)entity)));
}

public partial class BGSpecLevel : BGEntity
{

	public class Factory : BGEntity.EntityFactory
	{
		public BGEntity NewEntity(BGMetaEntity meta) => new BGSpecLevel(meta);
		public BGEntity NewEntity(BGMetaEntity meta, BGId id) => new BGSpecLevel(meta, id);
	}
	private static BansheeGz.BGDatabase.BGMetaRow _metaDefault;
	public static BansheeGz.BGDatabase.BGMetaRow MetaDefault => _metaDefault ?? (_metaDefault = BGCodeGenUtils.GetMeta<BansheeGz.BGDatabase.BGMetaRow>(new BGId(5752043033912480404UL,9697910417441021619UL), () => _metaDefault = null));
	public static BansheeGz.BGDatabase.BGRepoEvents Events => BGRepo.I.Events;
	public static int CountEntities => MetaDefault.CountEntities;
	public System.String name
	{
		get => _name[Index];
		set => _name[Index] = value;
	}
	public System.Int32 level
	{
		get => _level[Index];
		set => _level[Index] = value;
	}
	public System.Int32 requiredExp
	{
		get => _requiredExp[Index];
		set => _requiredExp[Index] = value;
	}
	private static BansheeGz.BGDatabase.BGFieldEntityName _ufle12jhs77_name;
	public static BansheeGz.BGDatabase.BGFieldEntityName _name => _ufle12jhs77_name ?? (_ufle12jhs77_name = BGCodeGenUtils.GetField<BansheeGz.BGDatabase.BGFieldEntityName>(MetaDefault, new BGId(4778670980871373507UL, 2917375248911112064UL), () => _ufle12jhs77_name = null));
	private static BansheeGz.BGDatabase.BGFieldInt _ufle12jhs77_level;
	public static BansheeGz.BGDatabase.BGFieldInt _level => _ufle12jhs77_level ?? (_ufle12jhs77_level = BGCodeGenUtils.GetField<BansheeGz.BGDatabase.BGFieldInt>(MetaDefault, new BGId(5228817346063835572UL, 5598329931351834787UL), () => _ufle12jhs77_level = null));
	private static BansheeGz.BGDatabase.BGFieldInt _ufle12jhs77_requiredExp;
	public static BansheeGz.BGDatabase.BGFieldInt _requiredExp => _ufle12jhs77_requiredExp ?? (_ufle12jhs77_requiredExp = BGCodeGenUtils.GetField<BansheeGz.BGDatabase.BGFieldInt>(MetaDefault, new BGId(4786487022336701800UL, 8102208771649927338UL), () => _ufle12jhs77_requiredExp = null));
	private static readonly BGSpecLand.Factory _factory0_PFS = new BGSpecLand.Factory();
	private static readonly BGSpecItem.Factory _factory1_PFS = new BGSpecItem.Factory();
	private static readonly BGSpecItemCraft.Factory _factory2_PFS = new BGSpecItemCraft.Factory();
	private static readonly BGSpecShopProb.Factory _factory3_PFS = new BGSpecShopProb.Factory();
	private static readonly BGSpecLevel.Factory _factory4_PFS = new BGSpecLevel.Factory();
	private static readonly BGSpecWeapon.Factory _factory5_PFS = new BGSpecWeapon.Factory();
	private BGSpecLevel() : base(MetaDefault) {}
	private BGSpecLevel(BGId id) : base(MetaDefault, id) {}
	private BGSpecLevel(BGMetaEntity meta) : base(meta) {}
	private BGSpecLevel(BGMetaEntity meta, BGId id) : base(meta, id) {}
	public static BGSpecLevel FindEntity(Predicate<BGSpecLevel> filter) => BGCodeGenUtils.FindEntity(MetaDefault, filter);
	public static List<BGSpecLevel> FindEntities(Predicate<BGSpecLevel> filter, List<BGSpecLevel> result=null, Comparison<BGSpecLevel> sort=null) => BGCodeGenUtils.FindEntities(MetaDefault, filter, result, sort);
	public static void ForEachEntity(Action<BGSpecLevel> action, Predicate<BGSpecLevel> filter=null, Comparison<BGSpecLevel> sort=null) => BGCodeGenUtils.ForEachEntity(MetaDefault, action, filter, sort);
	public static BGSpecLevel GetEntity(BGId entityId) => (BGSpecLevel) MetaDefault.GetEntity(entityId);
	public static BGSpecLevel GetEntity(int index) => (BGSpecLevel) MetaDefault[index];
	public static BGSpecLevel GetEntity(string entityName) => (BGSpecLevel) MetaDefault.GetEntity(entityName);
	public static BGSpecLevel NewEntity() => (BGSpecLevel) MetaDefault.NewEntity();
	public static BGSpecLevel NewEntity(BGId entityId) => (BGSpecLevel) MetaDefault.NewEntity(entityId);
	public static BGSpecLevel NewEntity(Action<BGSpecLevel> callback) => (BGSpecLevel) MetaDefault.NewEntity(new BGMetaEntity.NewEntityContext(entity => callback((BGSpecLevel)entity)));
}

public partial class BGSpecWeapon : BGEntity
{

	public class Factory : BGEntity.EntityFactory
	{
		public BGEntity NewEntity(BGMetaEntity meta) => new BGSpecWeapon(meta);
		public BGEntity NewEntity(BGMetaEntity meta, BGId id) => new BGSpecWeapon(meta, id);
	}
	private static BansheeGz.BGDatabase.BGMetaRow _metaDefault;
	public static BansheeGz.BGDatabase.BGMetaRow MetaDefault => _metaDefault ?? (_metaDefault = BGCodeGenUtils.GetMeta<BansheeGz.BGDatabase.BGMetaRow>(new BGId(5273903209608346129UL,1464165674114213807UL), () => _metaDefault = null));
	public static BansheeGz.BGDatabase.BGRepoEvents Events => BGRepo.I.Events;
	public static int CountEntities => MetaDefault.CountEntities;
	public System.String name
	{
		get => _name[Index];
		set => _name[Index] = value;
	}
	public System.Int32 fieldID
	{
		get => _fieldID[Index];
		set => _fieldID[Index] = value;
	}
	public System.Int32 grade
	{
		get => _grade[Index];
		set => _grade[Index] = value;
	}
	public System.Single coolDown
	{
		get => _coolDown[Index];
		set => _coolDown[Index] = value;
	}
	public float damage
	{
		get => _damage[Index];
		set => _damage[Index] = value;
	}
	public System.Int32 projectileID
	{
		get => _projectileID[Index];
		set => _projectileID[Index] = value;
	}
	private static BansheeGz.BGDatabase.BGFieldEntityName _ufle12jhs77_name;
	public static BansheeGz.BGDatabase.BGFieldEntityName _name => _ufle12jhs77_name ?? (_ufle12jhs77_name = BGCodeGenUtils.GetField<BansheeGz.BGDatabase.BGFieldEntityName>(MetaDefault, new BGId(5659106634718440428UL, 10906436684785901489UL), () => _ufle12jhs77_name = null));
	private static BansheeGz.BGDatabase.BGFieldInt _ufle12jhs77_fieldID;
	public static BansheeGz.BGDatabase.BGFieldInt _fieldID => _ufle12jhs77_fieldID ?? (_ufle12jhs77_fieldID = BGCodeGenUtils.GetField<BansheeGz.BGDatabase.BGFieldInt>(MetaDefault, new BGId(4843166303417800319UL, 394716045973414540UL), () => _ufle12jhs77_fieldID = null));
	private static BansheeGz.BGDatabase.BGFieldInt _ufle12jhs77_grade;
	public static BansheeGz.BGDatabase.BGFieldInt _grade => _ufle12jhs77_grade ?? (_ufle12jhs77_grade = BGCodeGenUtils.GetField<BansheeGz.BGDatabase.BGFieldInt>(MetaDefault, new BGId(5444483379748846421UL, 13274162939719790479UL), () => _ufle12jhs77_grade = null));
	private static BansheeGz.BGDatabase.BGFieldFloat _ufle12jhs77_coolDown;
	public static BansheeGz.BGDatabase.BGFieldFloat _coolDown => _ufle12jhs77_coolDown ?? (_ufle12jhs77_coolDown = BGCodeGenUtils.GetField<BansheeGz.BGDatabase.BGFieldFloat>(MetaDefault, new BGId(4898924853419677486UL, 17996283955200349082UL), () => _ufle12jhs77_coolDown = null));
	private static BansheeGz.BGDatabase.BGFieldFloat _ufle12jhs77_damage;
	public static BansheeGz.BGDatabase.BGFieldFloat _damage => _ufle12jhs77_damage ?? (_ufle12jhs77_damage = BGCodeGenUtils.GetField<BansheeGz.BGDatabase.BGFieldFloat>(MetaDefault, new BGId(5341952226922141128UL, 10749782415309673361UL), () => _ufle12jhs77_damage = null));
	private static BansheeGz.BGDatabase.BGFieldInt _ufle12jhs77_projectileID;
	public static BansheeGz.BGDatabase.BGFieldInt _projectileID => _ufle12jhs77_projectileID ?? (_ufle12jhs77_projectileID = BGCodeGenUtils.GetField<BansheeGz.BGDatabase.BGFieldInt>(MetaDefault, new BGId(4681212342128616853UL, 13978788006685345457UL), () => _ufle12jhs77_projectileID = null));
	private static readonly BGSpecLand.Factory _factory0_PFS = new BGSpecLand.Factory();
	private static readonly BGSpecItem.Factory _factory1_PFS = new BGSpecItem.Factory();
	private static readonly BGSpecItemCraft.Factory _factory2_PFS = new BGSpecItemCraft.Factory();
	private static readonly BGSpecShopProb.Factory _factory3_PFS = new BGSpecShopProb.Factory();
	private static readonly BGSpecLevel.Factory _factory4_PFS = new BGSpecLevel.Factory();
	private static readonly BGSpecWeapon.Factory _factory5_PFS = new BGSpecWeapon.Factory();
	private BGSpecWeapon() : base(MetaDefault) {}
	private BGSpecWeapon(BGId id) : base(MetaDefault, id) {}
	private BGSpecWeapon(BGMetaEntity meta) : base(meta) {}
	private BGSpecWeapon(BGMetaEntity meta, BGId id) : base(meta, id) {}
	public static BGSpecWeapon FindEntity(Predicate<BGSpecWeapon> filter) => BGCodeGenUtils.FindEntity(MetaDefault, filter);
	public static List<BGSpecWeapon> FindEntities(Predicate<BGSpecWeapon> filter, List<BGSpecWeapon> result=null, Comparison<BGSpecWeapon> sort=null) => BGCodeGenUtils.FindEntities(MetaDefault, filter, result, sort);
	public static void ForEachEntity(Action<BGSpecWeapon> action, Predicate<BGSpecWeapon> filter=null, Comparison<BGSpecWeapon> sort=null) => BGCodeGenUtils.ForEachEntity(MetaDefault, action, filter, sort);
	public static BGSpecWeapon GetEntity(BGId entityId) => (BGSpecWeapon) MetaDefault.GetEntity(entityId);
	public static BGSpecWeapon GetEntity(int index) => (BGSpecWeapon) MetaDefault[index];
	public static BGSpecWeapon GetEntity(string entityName) => (BGSpecWeapon) MetaDefault.GetEntity(entityName);
	public static BGSpecWeapon NewEntity() => (BGSpecWeapon) MetaDefault.NewEntity();
	public static BGSpecWeapon NewEntity(BGId entityId) => (BGSpecWeapon) MetaDefault.NewEntity(entityId);
	public static BGSpecWeapon NewEntity(Action<BGSpecWeapon> callback) => (BGSpecWeapon) MetaDefault.NewEntity(new BGMetaEntity.NewEntityContext(entity => callback((BGSpecWeapon)entity)));
}
#pragma warning restore 414
