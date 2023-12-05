using System.Collections;
using UnityEngine;

public class GameStateBattle : GameState
{
    private WaitUntil _waitUntil = new WaitUntil(() => !SpawnManager.Instance.IsSpawning);
    private WaitForSeconds WaitForSeconds = new WaitForSeconds(0.05f);
    public override void Enter()
    {
        
    }

    public override IEnumerator Execute()
    {
        yield return new WaitUntil(() => !SpawnManager.Instance.IsSpawning);

        int count = 0;

        while (InGameManager.Instance.IsEnoughCurrency(Enum_Currency.Blood, 1))
        {
            InGameManager.Instance.TryConsumeCurrency(Enum_Currency.Blood, 1);
            count++;
            if (count >= 10)
            {
                count %= 10;
                InGameManager.Instance.CurrencySystem.AddCurrency(Enum_Currency.Gold,1);
            }

            yield return WaitForSeconds;
        }
        
        InGameManager.Instance.TryNextHandleStart();
    }

    public override void Exit()
    {
        
    }
}