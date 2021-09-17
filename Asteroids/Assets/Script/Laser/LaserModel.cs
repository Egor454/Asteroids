using UnityEngine;
using System;
public class LaserModel : ILaserModel
{
    private GameObject laser;

    private int timeShooting = 5;

    public event Action<int> StartShoot;

    public LaserModel(GameObject gameObject)
    {
        laser = gameObject;
    }

    public void StartTimeLaserShoot()
    {
        StartShoot?.Invoke(timeShooting);
    }

    public void StopWorkLaser()
    {
        laser.gameObject.SetActive(false);
    }
}
