
using System.Collections;
using UnityEngine;

public class GameStateReward : GameState
{
    private WaitForSeconds _waitForSeconds = new WaitForSeconds(2f);
    
    public override void Enter()
    {
        
    }

    public override IEnumerator Execute()
    {
        yield return _waitForSeconds;
        
        InGameManager.Instance.TryNextHandleStart();
    }

    public override void Exit()
    {
        
    }
}
