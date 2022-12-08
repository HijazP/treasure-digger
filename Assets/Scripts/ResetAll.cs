using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetAll : MonoBehaviour
{
    public void Reset()
    {
        RandomTreasure.instance.PrefabReset();
        PlayerMovement.instance.ResetPost();
        ActiveGM.instance.Active();
        ScoreManager.instance.ResetScore();
        TimerCD.instance.ResetTime();
    }
}
