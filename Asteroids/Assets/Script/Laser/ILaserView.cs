using System;

public interface ILaserView
{
    event Action laserActivated;
    event Action laserCantShoot;
    event Action UninitializePresenter;

    void StartTimerShoot(int time);
}
