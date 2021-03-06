using System;
using UnityEngine;

public class ShipModel : IShipModel
{
    private GameObject laserObj;
    private ITimer timer;
    private Transform transform;

    private float speed = 0.0001f;
    private float acceleration = 0;
    private float moveSpeed = 0;
    private float constantAcceleration = 0.00001f;
    private float constantBraking = 0.03f;
    private float speedRotate = 1.5f;
    private float maxMoveSpeed = 0.07f;
    private float minMoveSpeed = 0;
    private int countShootLaser = 3;
    private int countShootLaserMax = 3;
    private float timeReloud = 30;
    private float timePassedText = 0;
    private bool laserIsReloud = false;

    public event Action<float, int, float> sendDataModel;
    public event Action shipDestroy;

    public ShipModel(Transform transforms, ITimer times)
    {
        timer = times;
        transform = transforms;

        timer.timePassed += SetTimePassed;
        timer.ready += ReloudLaserCount;
    }

    public void MoveShip()
    {
        if (moveSpeed < maxMoveSpeed)
        {
            moveSpeed += speed + acceleration * Time.deltaTime;
            acceleration += constantAcceleration;
        }
        transform.position += transform.up * moveSpeed;

    }

    public void RotateShip(Vector3 directionOfRotation)
    {
        transform.Rotate(directionOfRotation.y * speedRotate, directionOfRotation.y * speedRotate, directionOfRotation.x * (-speedRotate));
    }

    public void BrakingShip()
    {
        if (moveSpeed > minMoveSpeed)
        {
            moveSpeed -= constantBraking * Time.deltaTime;
            acceleration = 0;
            transform.position += transform.up * moveSpeed;
        }
        else
        {
            moveSpeed = 0;
        }
    }

    public void StartShootBullet(IBulletView bullet)
    {
        IBulletModel bulletModel = new BulletModel();
        IBulletPresenter bulletPresenter = new BulletPresenter(bullet, bulletModel);
    }

    public void StartShootLaser(GameObject laser)
    {
        if (laserObj == null)
        {
            laserObj = laser;
            ILaserView laserView = laserObj.GetComponent<ILaserView>();
            ILaserModel laserModel = new LaserModel(laserObj);
            ILaserPresenter laserPresenter = new LaserPresenter(laserView, laserModel);
        }

        if (countShootLaser != 0)
        {
            laserObj.SetActive(true);
            countShootLaser--;
            StartReloudLaser();
        }
    }

    public void StartReloudLaser()
    {
        if (countShootLaser != countShootLaserMax && !laserIsReloud)
        {
            laserIsReloud = true;
            timer.TimerNeedOn(timeReloud);
        }
    }

    private void ReloudLaserCount()
    {
        countShootLaser++;
        laserIsReloud = false;
    }

    private void SetTimePassed(float time)
    {
        timePassedText = time;
    }

    public void DieShip()
    {
        shipDestroy?.Invoke();
    }

    public void SendData()
    {
        sendDataModel?.Invoke(moveSpeed, countShootLaser, timePassedText);
    }
}
