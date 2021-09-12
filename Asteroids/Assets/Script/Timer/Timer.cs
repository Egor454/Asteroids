using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public UnityAction<float> timePassed;
    public UnityAction ready;

    private float timeReloud;
    private bool timeStart = false;
    private float timeLeft;

    void Update()
    {
        if (timeStart)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                timePassed?.Invoke(timeLeft);
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
