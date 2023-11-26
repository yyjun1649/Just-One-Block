using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LandSet : MonoBehaviour
{
    public int LineIndex;
    public List<Land> Lands;
    List<int> onIntList = new List<int>();
    
    public void Initialize(int index)
    {
        LineIndex = index;

        for (int i = 0; i < Lands.Count; i++)
        {
            Lands[i].Initialize(-1,LineIndex,i);
        }
    }

    public void SetLandOn()
    {
        foreach (var land in Lands)
        {
            land.SetActive(land.LandID >= 0);
        }
        
        for (int i = 0; i < Lands.Count; i++)
        {
            var land = Lands[i];

            if (land.LandID < 0) { continue; }

            if (i > 0)
            {
                Lands[i-1].SetActive(true);
            }
            
            if (i < Lands.Count-1)
            {
                Lands[i+1].SetActive(true);
            }
        }
    }

    public List<int> GetLandOn()
    {
        onIntList.Clear();

        for (int i = 0; i < Lands.Count; i++)
        {
            var id = Lands[i].LandID;
            
            if(id < 0) {continue;}
            
            onIntList.Add(i);
        }

        return onIntList;
    }

    public void RewardStackPush()
    {
        foreach (var land in Lands)
        {
            var reward = land.GetReward();

            if (reward == null)
            {
                continue;
            }
            
            RewardManager.PushReward(reward);
        }
    }
}
