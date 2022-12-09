using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetAll : MonoBehaviour
{
    public void Reset()
    {
        RandomTreasure.instance.PrefabReset();
        PlayerMovement.instance.ResetPost();

        if (BFS.instance != null)
        {
            BFS.instance.ResetPost();
        }

        if (DFS.instance != null)
        {
            DFS.instance.ResetPost();
        }

        ActiveGM.instance.Active();
        ScoreManager.instance.ResetScore();
        TimerCD.instance.ResetTime();
    }
}
