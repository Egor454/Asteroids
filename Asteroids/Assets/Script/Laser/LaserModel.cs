using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserModel
{
    private LaserView laser;

    private int timeShooting = 5;

    public LaserModel(LaserView laserView)
    {
        laser = laserView;

        laser.laserActivated += StartTimeLaserEndShoot;
        laser.laserCantShoot += StopWorkLaser;
    }

    private void StartTimeLaserEndShoot()
    {
        laser.StartTimerShoot(timeShooting);
    }

    private void StopWorkLaser()
    {
        laser.gameObject.SetActive(false);
    }
}
