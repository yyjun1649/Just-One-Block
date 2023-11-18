using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Currency_Slot : MonoBehaviour, GameEventListener<CurrencyEvent>
{
    [SerializeField] private Image _imgCurrency;
    [SerializeField] private TextMeshProUGUI _txtAmount;

    private Enum_Currency _currencyType;
    
    public void Initalize(Enum_Currency currency)
    {
        _currencyType = currency;

        if (_currencyType == Enum_Currency.None)
        {
            gameObject.SetActive(false);
            return;
        }
        
        gameObject.SetActive(true);
    }

    public void Refresh()
    {
        
    }

    public void OnGameEvent(CurrencyEvent gameEventType)
    {
        if (gameEventType.Type == _currencyType)
        {
            Refresh();
        }
    }
}
