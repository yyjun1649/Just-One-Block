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
        this.AddGameEventListening<CurrencyEvent>();
        _currencyType = currency;

        if (_currencyType == Enum_Currency.None)
        {
            gameObject.SetActive(false);
            return;
        }

        Refresh();
        
        gameObject.SetActive(true);
    }

    public void Refresh()
    {
        if (_currencyType == Enum_Currency.None)
        {
            return;
        }
        
        _imgCurrency.sprite = ResourceManager.Instance.GetIconSprite(Enum_IconType.Currency, (int)_currencyType);
        _txtAmount.text = $"{InGameManager.Instance.CurrencySystem.GetCurrencyAmount(_currencyType)}";
    }

    public void OnGameEvent(CurrencyEvent gameEventType)
    {
        if (gameEventType.Type == _currencyType)
        {
            Refresh();
        }
    }
}
