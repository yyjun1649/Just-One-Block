using System.Collections.Generic;
using EnhancedUI.EnhancedScroller;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(EnhancedScroller), typeof(Mask))]
public abstract class UI_EnhancedScroller<TCellView, TData> : MonoBehaviour, IEnhancedScrollerDelegate where TCellView : EnhancedScrollerCellView
{ 
    [SerializeField] protected EnhancedScroller _enhancedScroller;
    [SerializeField] private TCellView _slotPrefab;
    
    private TData[] _dataArray;
    private List<TData> _dataList;
    private float _slotSize;

    public virtual void Initialize(TData[] dataList)
    {
        if (dataList == null)
        {
            return;
        }
        
        _dataArray = dataList;

        SetInitalize();
    }
    
    public virtual void Initialize(List<TData> dataList)
    {
        if (dataList == null)
        {
            return;
        }
        
        _dataList = dataList;

        SetInitalize();
    }

    private void SetInitalize()
    {
        if (_slotSize <= 0)
        {
            var slotRect = _slotPrefab.GetComponent<RectTransform>();
            
            _slotSize = _enhancedScroller.scrollDirection == EnhancedScroller.ScrollDirectionEnum.Vertical
                ? slotRect.rect.height
                : slotRect.rect.width;
        }
        
        _enhancedScroller.Delegate = this;
        _enhancedScroller.ReloadData();

        OnInitialized();
    }
    
    protected virtual void OnInitialized()
    {}

    public virtual void Refresh()
    {
        _enhancedScroller.RefreshActiveCellViews();
    }

    public int GetNumberOfCells(EnhancedScroller scroller)
    {
        if (_dataArray != null)
        {
            return _dataArray.Length;
        }
        else if(_dataList != null)
        {
            return _dataList.Count;
        }

        return 0;
    }

    public float GetCellViewSize(EnhancedScroller scroller, int dataIndex)
    {
        return _slotSize;
    }

    protected abstract void RefreshCellView(TCellView cellView, TData data);
    

    public EnhancedScrollerCellView GetCellView(EnhancedScroller scroller, int dataIndex, int cellIndex)
    {
        TCellView cellView = scroller.GetCellView(_slotPrefab) as TCellView;
        
        if (_dataArray != null)
        {
            RefreshCellView(cellView, _dataArray[dataIndex]);
        }
        else if (_dataList != null)
        {
            RefreshCellView(cellView, _dataList[dataIndex]);
        }
        
        return cellView;
    }


    public void Reset()
    {
        _enhancedScroller = GetComponent<EnhancedScroller>();

        var horizontal = GetComponentInChildren<HorizontalLayoutGroup>();
        var vertical = GetComponentInChildren<VerticalLayoutGroup>();

        if (horizontal != null)
        {
            _enhancedScroller.padding = horizontal.padding;
            _enhancedScroller.spacing = horizontal.spacing;

            _enhancedScroller.scrollDirection = EnhancedScroller.ScrollDirectionEnum.Horizontal;
        }
        else if (vertical != null)
        {
            _enhancedScroller.padding = vertical.padding;
            _enhancedScroller.spacing = vertical.spacing;

            _enhancedScroller.scrollDirection = EnhancedScroller.ScrollDirectionEnum.Vertical;
        }
    }

    public RectTransform GetContainer()
    {
        return _enhancedScroller.Container;
    }
}