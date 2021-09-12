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

    private float speed = 0.0001f;
    private float acceleration = 0;
    private float moveSpeed = 0;
    private float constantAcceleration = 0.00001f;
    private float constantBraking = 0.01f;
    private float speedRotate = 1.5f;
    private float maxMoveSpeed = 0.07f;
    private float minMoveSpeed = 0;

    private int countShootLaser = 3;
    private int countShootLaserMax = 3;
    private int timeReloud = 10;

    public EngineShip(ShipView shipview)
    {
        this.shipView = shipview;

        shipView.shipStartMove += MoveShip;
        shipView.shipStartRotate += RotateShip;
        shipview.shipStopMove += BrakingShip;
        shipView.shipShootBullet += StartShootBullet;
        shipView.shipShootLaser += StartShootLaser;
        shipView.laserReloud += ReloudLaserCount;
    }

    private void MoveShip(Transform transform)
    {
        if(moveSpeed < maxMoveSpeed)
        {
            moveSpeed += speed + acceleration * Time.deltaTime;
            acceleration += constantAcceleration;
        }
        transform.position += transform.up * moveSpeed;

    }

    private void RotateShip(Transform transform, Vector3 directionOfRotation)
    {
        transform.Rotate(directionOfRotation.y * speedRotate, directionOfRotation.y * speedRotate, directionOfRotation.x * (-speedRotate));
    }

    private void BrakingShip(Transform transform)
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
            ReloudLaser();
        }
    }

    private void ReloudLaser()
    {
        if(countShootLaser != countShootLaserMax)
        {
            shipView.StartReloudTimerView(timeReloud);
        }
    }

    private void ReloudLaserCount()
    {
        countShootLaser++;
    }
    
}
