using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerCD : MonoBehaviour
{
    public static TimerCD instance;

    public float timeRemaining = 0;
    public bool timerIsRunning = false;
    public Text timeText;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            timeRemaining += Time.deltaTime;
            DisplayTime(timeRemaining);
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float milliSeconds = (timeToDisplay % 1) * 1000;
        timeText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliSeconds);
    }

    public void Play()
    {
        timerIsRunning = true;
    }

    public void Stop()
    {
        timerIsRunning = false;
    }

    public void ResetTime()
    {
        Stop();
        timeRemaining = 0;
        DisplayTime(timeRemaining);
    }
}