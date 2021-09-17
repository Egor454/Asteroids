using UnityEngine;
using System;
using UnityEngine.InputSystem;
public interface IShipView 
{
    event Action shipStartMove;
    event Action<Vector3> shipStartRotate;
    event Action shipStopMove;
    event Action checkLaserCountShoot;
    event Action<IBulletView> shipShootBullet;
    event Action<GameObject> shipShootLaser;
    event Action haveCollision;
    event Action UninitializePresenter;

    void Move(InputAction.CallbackContext context);
    void Rotation(InputAction.CallbackContext value);
    void FireBullet(InputAction.CallbackContext context);
    void FireLaser(InputAction.CallbackContext context);
}
