using System;
using UnityEngine;

public class EnemyShipPresenter : IEnemyShipPresenter
{
    private IEnemyShipView enemyView;
    private IEnemyShipModel enemyModel;

    public event Action<GameObject> EnemyShipWasDestroy;

    public EnemyShipPresenter(IEnemyShipView view, IEnemyShipModel model)
    {
        enemyView = view;
        enemyModel = model;
        Initialize();
    }

    private void EnemyShipNeedMovePresenter()
    {
        enemyModel.Move();
    }

    private void WhenDestroyPresenter()
    {
        enemyModel.Destroy();
    }

    private void WasDestroyEnemyShip(GameObject obj)
    {
        EnemyShipWasDestroy?.Invoke(obj);
    }

    private void DestroyEnemyShipPresenter(float time)
    {
        enemyView.DestroyEnemyShipView(time);
    }

    private void Initialize()
    {
        enemyView.enemyShipNeedMove += EnemyShipNeedMovePresenter;
        enemyView.whenDestroy += WhenDestroyPresenter;
        enemyView.wasDestroy += WasDestroyEnemyShip;

        enemyModel.destroyEnemyShip += DestroyEnemyShipPresenter;
    }
    private void Uninitialize()
    {
        enemyView.enemyShipNeedMove -= EnemyShipNeedMovePresenter;
        enemyView.whenDestroy -= WhenDestroyPresenter;
        enemyView.wasDestroy -= WasDestroyEnemyShip;

        enemyModel.destroyEnemyShip -= DestroyEnemyShipPresenter;
    }
}
