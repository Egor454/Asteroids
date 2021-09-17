using System;
using UnityEngine;

public class ShipPresenter: IShipPresenter
{
    private  IShipView shipView;
    private IShipModel shipModel;

    public event Action<float, int, float> sendDataPresenter;
    public event Action shipWasDestroy;

    public ShipPresenter(IShipView view, IShipModel model)
    {
        shipView = view;
        shipModel = model;
        Initialize();
    }

    private void ShipStartMovePresenter()
    {
        shipModel.MoveShip();
    }

    private void ShipStartRotatePresenter(Vector3 directionOfRotation)
    {
        shipModel.RotateShip(directionOfRotation);
    }

    private void ShipStopMovePresenter()
    {
        shipModel.BrakingShip();
    }

    private void CheckLaserCountShootPresenter()
    {
        shipModel.StartReloudLaser();
    }

    private void ShipShootBulletPresenter(IBulletView bullet)
    {
        shipModel.StartShootBullet(bullet);
    }

    private void ShipShootLaserPresenter(GameObject laserPrefab)
    {
        shipModel.StartShootLaser(laserPrefab);
    }

    private void HaveCollisionPresenter()
    {
        shipModel.DieShip();
    }

    private void SendDataPresenter(float speed, int countLaser,float timeReloud)
    {
        sendDataPresenter?.Invoke(speed, countLaser, timeReloud);
    }

    private void ShipWasDestroy()
    {
        shipWasDestroy?.Invoke();
    }

    public void TakeData()
    {
        shipModel.SendData();
    }

    public void Initialize()
    {
        shipView.shipStartMove += ShipStartMovePresenter;
        shipView.shipStartRotate += ShipStartRotatePresenter;
        shipView.shipStopMove += ShipStopMovePresenter;
        shipView.checkLaserCountShoot += CheckLaserCountShootPresenter;
        shipView.shipShootBullet += ShipShootBulletPresenter;
        shipView.shipShootLaser += ShipShootLaserPresenter;
        shipView.haveCollision += HaveCollisionPresenter;
        shipView.UninitializePresenter += Uninitialize;

        shipModel.sendDataModel += SendDataPresenter;
        shipModel.shipDestroy += ShipWasDestroy;

    }
    public void Uninitialize()
    {
        shipView.shipStartMove -= ShipStartMovePresenter;
        shipView.shipStartRotate -= ShipStartRotatePresenter;
        shipView.shipStopMove -= ShipStopMovePresenter;
        shipView.checkLaserCountShoot -= CheckLaserCountShootPresenter;
        shipView.shipShootBullet -= ShipShootBulletPresenter;
        shipView.shipShootLaser -= ShipShootLaserPresenter;
        shipView.haveCollision -= HaveCollisionPresenter;
        shipView.UninitializePresenter -= Uninitialize;

        shipModel.sendDataModel -= SendDataPresenter;
        shipModel.shipDestroy -= ShipWasDestroy;
    }
}
