using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPresenter : IBulletPresenter
{
    private IBulletView bulletView;
    private IBulletModel bulletModel;

    public BulletPresenter(IBulletView view, IBulletModel model)
    {
        bulletView = view;
        bulletModel = model;
        Initialize();
    }

    private void BulletIsMovePresenter()
    {
        bulletModel.Move();
    }

    private void WhenDestroyBulletPresenter()
    {
        bulletModel.Destroy();
    }

    private void DestroyBulletPresenter(float time)
    {
        bulletView.DestroyBulletView(time);
    }

    private void SetTransformPositionPresenter(Transform transform)
    {
        bulletModel.SetTransform(transform);
    }

    private void Initialize()
    {
        bulletView.bulletIsMove += BulletIsMovePresenter;
        bulletView.whenDestroy += WhenDestroyBulletPresenter;
        bulletView.setTransformPosition += SetTransformPositionPresenter;
        bulletModel.DestroyBullet += DestroyBulletPresenter;
        bulletView.uninitializePresenter += Uninitialize;

    }
    private void Uninitialize()
    {
        bulletView.bulletIsMove -= BulletIsMovePresenter;
        bulletView.whenDestroy -= WhenDestroyBulletPresenter;
        bulletView.setTransformPosition -= SetTransformPositionPresenter;
        bulletModel.DestroyBullet -= DestroyBulletPresenter;
    }

}
