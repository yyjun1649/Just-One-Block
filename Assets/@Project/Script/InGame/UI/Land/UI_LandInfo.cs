using UnityEngine;
using UnityEngine.UI;

public class UI_LandInfo : SingletonBehaviour<UI_LandInfo>
{
    [SerializeField] private RectTransform _popup;
    [SerializeField] private RectTransform _child;
    [SerializeField] private Camera _cam;
    
    [SerializeField] private Text _txtTitle;
    [SerializeField] private Text _txtPrice;

    protected override void Awake()
    {
        base.Awake();
        Close();
    }

    public void Open(int index)
    {
        _txtTitle.text = $"Land_{index}";
        _txtPrice.text = $"{SpecDataManager.Instance.SpecLandData[index].price - 1}";
        
        SetPosition();
    }
    
    private void SetPosition()
    {
        var screenPos = _cam.ScreenToWorldPoint(Input.mousePosition);
        
        var pivotX = screenPos.x > 0 ? 1 : 0;
        var pivotY = screenPos.y > 0 ? 1 : 0;

        screenPos.z = 0;
        _popup.transform.position = screenPos;
        _child.pivot = new Vector2(pivotX, pivotY);
        _child.anchoredPosition = Vector2.zero;
        
        gameObject.SetActive(true);
    }
    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Close();
        }   
    }

    private void Close()
    {
        gameObject.SetActive(false);
    }

    public void OnClickSell()
    {
        
    }
}