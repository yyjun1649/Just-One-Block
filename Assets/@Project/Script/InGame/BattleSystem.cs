
using UnityEngine;

public class BattleSystem
{
    [SerializeField] private UI_Battle _uiBattle;

    public void ShowUI()
    {
        _uiBattle.Initialize();
    }

}
