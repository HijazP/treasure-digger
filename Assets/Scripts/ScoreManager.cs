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
        if (BFS.instance != null)
        {
            if (score == 2)
            {
                BFS.instance.UpdateEdge(-1.5f);
                BFS.instance.ChangeDirection();
            }
            else if (score == 6)
            {
                BFS.instance.UpdateEdge(-2.5f);
                BFS.instance.ChangeDirection();
            }
            else if (score == 14)
            {
                BFS.instance.UpdateEdge(-3.5f);
                BFS.instance.ChangeDirection();
            }
        }

        // if (DFS.instance != null)
        // {
        //     if (score == 1)
        //     {
        //         DFS.instance.UpdateEdge(-1.5f);
        //         DFS.instance.ChangeDirection();
        //         DFS.instance.DirectionEdge(false, true);
        //     }
        //     else if (score == 2)
        //     {
        //         DFS.instance.UpdateEdge(-2.5f);
        //         DFS.instance.ChangeDirection();
        //         DFS.instance.DirectionEdge(false, true);
        //     }
        //     else if (score == 3)
        //     {
        //         DFS.instance.UpdateEdge(-3.5f);
        //         DFS.instance.ChangeDirection();
        //         DFS.instance.DirectionEdge(false, true);
        //     }
        //     else if (score == 5)
        //     {
        //         DFS.instance.UpdateEdge(-3.5f);
        //         DFS.instance.ChangeDirection();
        //         DFS.instance.DirectionEdge(true, false);
        //     }
        //     else if (score == 7)
        //     {
        //         DFS.instance.UpdateEdge(-2.5f);
        //         DFS.instance.ChangeDirection();
        //         DFS.instance.DirectionEdge(true, false);
        //     }
        // }

        if (score == 30)
        {
            TimerCD.instance.Stop();
            
            if (BFS.instance != null)
            {
                BFS.instance.Stop();
            }
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
