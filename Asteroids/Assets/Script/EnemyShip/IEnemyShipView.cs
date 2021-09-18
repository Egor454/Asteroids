using System;
using UnityEngine;

public interface IEnemyShipView
{
    event Action enemyShipNeedMove;
    event Action whenDestroy;
    event Action<GameObject> wasDestroy;

    void DestroyEnemyShipView(float time);
}
