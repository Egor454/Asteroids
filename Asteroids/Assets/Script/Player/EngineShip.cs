using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EngineShip
{
    private ShipView shipView;
    private LaserModel laserModel;
    private LaserView laserView;
    private GameObject laserObj;
    private Timer timer;
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

    public int CountShootLaser => countShootLaser;
    public float TimePassedText => timePassedText;
    public float MoveSpeed => moveSpeed;

    public UnityAction shipDestroy;

    public EngineShip(ShipView shipview)
    {
        this.shipView = shipview;
        timer = shipView.gameObject.GetComponent<Timer>();
        transform = shipView.gameObject.GetComponent<Transform>();

        shipView.shipStartMove += MoveShip;
        shipView.shipStartRotate += RotateShip;
        shipview.shipStopMove += BrakingShip;
        shipView.shipShootBullet += StartShootBullet;
        shipView.shipShootLaser += StartShootLaser;
        shipView.laserReloud += ReloudLaserCount;
        shipView.checkLaserCountShoot += StartReloudLaser;
        shipview.haveCollision += DieShip;

        timer.timePassed += SetTimePassed;
        timer.ready += ReloudLaserCount;
    }

    private void MoveShip()
    {
        if(moveSpeed < maxMoveSpeed)
        {
            moveSpeed += speed + acceleration * Time.deltaTime;
            acceleration += constantAcceleration;
        }
        transform.position += transform.up * moveSpeed;

    }

    private void RotateShip(Vector3 directionOfRotation)
    {
        transform.Rotate(directionOfRotation.y * speedRotate, directionOfRotation.y * speedRotate, directionOfRotation.x * (-speedRotate));
    }

    private void BrakingShip()
    {
        if ( moveSpeed > minMoveSpeed)
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

    private void StartShootBullet(BulletView bullet)
    {
        BulletModel bulletModel = new BulletModel(bullet);
    }

    private void StartShootLaser(GameObject laser)
    {
        if(laserObj == null)
        {
            laserObj = laser;
            laserView = laserObj.GetComponent<LaserView>();
            laserModel = new LaserModel(laserView);
        }

       if(countShootLaser != 0)
        {
            laserView.gameObject.SetActive(true);
            countShootLaser--;
            StartReloudLaser();
        }
    }

    private void StartReloudLaser()
    {
        if(countShootLaser != countShootLaserMax && !laserIsReloud)
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

    private void DieShip()
    {
        shipDestroy?.Invoke();
    }
}
