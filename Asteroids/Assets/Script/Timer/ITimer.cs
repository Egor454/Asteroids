using System;
public interface ITimer
{
    event Action<float> timePassed;
    event Action ready;

    void TimerNeedOn(float time);
}
