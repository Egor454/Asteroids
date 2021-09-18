using System;
public interface IEnemyShipModel
{
    event Action<float> destroyEnemyShip;

    void Destroy();
    void Move();
}
