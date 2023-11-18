using UnityEngine;

public class UI_Currency : MonoBehaviour
{
    [SerializeField] private UI_Currency_Slot[] _slots;
    
    public void SetUI(params Enum_Currency[] currencies)
    {
        for (int i = 0; i < _slots.Length; i++)
        {
            if (i >= currencies.Length)
            {
                _slots[i].Initalize(Enum_Currency.None);
                continue;
            }
            
            _slots[i].Initalize(currencies[i]);
        }
    }
}
