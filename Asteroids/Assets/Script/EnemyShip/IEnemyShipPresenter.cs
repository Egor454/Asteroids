using System;
using UnityEngine;

public interface IEnemyShipPresenter
{
    event Action<GameObject> EnemyShipWasDestroy;
}
