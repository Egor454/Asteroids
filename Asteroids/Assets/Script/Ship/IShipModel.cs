using UnityEngine;
using System;
public interface IShipModel
{
    event Action<float,int,float> sendDataModel;
    event Action shipDestroy;

    void MoveShip();
    void RotateShip(Vector3 directionOfRotation);
    void BrakingShip();
    void StartShootBullet(IBulletView bullet);
    void StartShootLaser(GameObject laser);
    void StartReloudLaser();
    void DieShip();
    void SendData();
}
