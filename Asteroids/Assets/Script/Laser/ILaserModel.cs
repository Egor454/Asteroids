using System;

public interface ILaserModel
{
    event Action<int> StartShoot;

    void StartTimeLaserShoot();
    void StopWorkLaser();
}
