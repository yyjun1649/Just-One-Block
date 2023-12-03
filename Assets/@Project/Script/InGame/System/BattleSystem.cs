
using UnityEngine;

public class BattleSystem : PlaySystem
{
    [SerializeField] private UI_Battle _uiBattle;

    public override void Initialize()
    {
        ShowOffUI();
    }

    public void ShowUI()
    {
        _uiBattle.Initialize();
    }

    public void ShowOffUI()
    {
        _uiBattle.Close();
    }
}
