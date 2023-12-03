using System.Collections;
using System.Collections.Generic;
using EnhancedUI.EnhancedScroller;
using UnityEngine;

public class UI_CraftInfo : MonoBehaviour
{
    [SerializeField] private List<UI_SpecItemSlot> _itemSlots;
    [SerializeField] private List<UI_CraftItemSlot> _haveSlots;

    [SerializeField] private UI_CraftSlot _resultSlot;

    [SerializeField] private GameObject _goX;
    [SerializeField] private GameObject _goButtonDisable;

    private SpecItemCraft _specCraft;

    [SerializeField] private GameObject _goExist;
    [SerializeField] private GameObject _goDisable;
    
    public void Init(SpecItemCraft specCraft)
    {
        _specCraft = specCraft;
        
        if (specCraft == null)
        {
            _goDisable.SetActive(true);
            _goExist.SetActive(false);
            return;
        }

        var spec = SpecDataManager.Instance.SpecItemData;
        var specResourceId = specCraft.resourceItemId;
        var specResourceCount = specCraft.resourceCount;
        for (int i = 0; i < _itemSlots.Count; i++)
        {
            if (i >= specResourceId.Count)
            {
                _itemSlots[i].gameObject.SetActive(false);
                continue;
            }
            
            var id = specResourceId[i];
            var count = specResourceCount[i];
            
            _itemSlots[i].SetAmount(count).Init(spec[id]);
        }
       
        for (int i = 0; i < _haveSlots.Count; i++)
        {
            if (i >= specResourceId.Count)
            {
                _haveSlots[i].gameObject.SetActive(false);
                continue;
            }
            
            var id = specResourceId[i];
            var count = specResourceCount[i];
            _haveSlots[i].Init(id,count);
        }

        var specCraftResult = SpecDataManager.Instance.SpecItemCraftData[specCraft.itemId];
        
        _resultSlot.Init(specCraftResult,null);

        var isEnableCraft = InGameManager.Instance.EquipmentCraftingSystem.IsEnableCraft(specCraft);
        
        _goX.SetActive(!isEnableCraft);
        _goButtonDisable.SetActive(!isEnableCraft);
        
        _goDisable.SetActive(false);
        _goExist.SetActive(true);
    }

    public void OnClickCraft()
    {
        if (InGameManager.Instance.EquipmentCraftingSystem.TryCraft(_specCraft))
        {
            RefreshEvent.Trigger(Enum_RefreshEventType.Item);
        }
    }
}
