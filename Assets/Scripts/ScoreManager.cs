using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    
    private int score = 0;
    public Text scoreText;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (score == 30)
        {
            TimerCD.instance.Stop();
        }
    }

    public void AddScore()
    {
        score++;
        scoreText.text = string.Format("{0:00}", score);
    }

    public void ResetScore()
    {
        score = 0;
        scoreText.text = string.Format("{0:00}", score);
    }
}
