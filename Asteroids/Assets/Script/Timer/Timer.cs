using System;
using UnityEngine;

public class Timer : MonoBehaviour, ITimer
{
    public event Action<float> timePassed;
    public event Action ready;

    private bool timeStart = false;
    private float timeLeft;

    void Update()
    {
        if (timeStart)
        {
            timeLeft -= Time.deltaTime;
            timePassed?.Invoke(timeLeft);
            if (timeLeft < 0)
            {
                ready?.Invoke();
                timeStart = false;
            }
        }

    }

    public void TimerNeedOn(float time)
    {
        timeStart = true;
        timeLeft = time;
    }
}
