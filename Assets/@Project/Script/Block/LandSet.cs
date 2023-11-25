using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandSet : MonoBehaviour
{
    public int LineIndex;
    public List<Land> Lands;

    public void Initialize(int index)
    {
        LineIndex = index;

        for (int i = 0; i < Lands.Count; i++)
        {
            Lands[i].Initialize(-1,LineIndex,i);
        }
    }

    public void RewardStackPush()
    {

    }
}
