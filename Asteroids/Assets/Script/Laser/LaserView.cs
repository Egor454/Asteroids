using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class LaserView : MonoBehaviour
{
    public UnityAction laserActivated;
    public UnityAction laserCantShoot;

    private void OnEnable()
    {
        laserActivated?.Invoke();
    }

    public void StartTimerShoot(int time)
    {
        StartCoroutine(ShootTimer(time));
    }

    public IEnumerator ShootTimer(int timer)
    {
        yield return new WaitForSeconds(timer);
        laserCantShoot?.Invoke();
    }
}
