using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class LaserView : MonoBehaviour,ILaserView
{
    public event Action laserActivated;
    public event Action laserCantShoot;
    public event Action UninitializePresenter;

    private void OnEnable()
    {
        laserActivated?.Invoke();
    }

    public void StartTimerShoot(int time)
    {
        StartCoroutine(ShootTimer(time));
    }

    private IEnumerator ShootTimer(int timer)
    {
        yield return new WaitForSeconds(timer);
        laserCantShoot?.Invoke();
    }

    private void OnDestroy()
    {
        UninitializePresenter?.Invoke();
    }
}
