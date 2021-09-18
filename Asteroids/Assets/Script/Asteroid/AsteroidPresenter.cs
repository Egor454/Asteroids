using System;
using UnityEngine;

public class AsteroidPresenter : IAsteroidPresenter
{
    private IAsteroidView asteroidView;
    private IAsteroidModel asteroidModel;

    public event Action<GameObject> asteroidWasDestroy;
    public event Action<Transform, float> needSplitAsteroid;

    public AsteroidPresenter(IAsteroidView view, IAsteroidModel model)
    {
        asteroidView = view;
        asteroidModel = model;
        InitializePresenter();
    }

    private void AsteroidNeedMovePresenter()
    {
        asteroidModel.Move();
    }

    private void WhenDestroyPresenter()
    {
        asteroidModel.Destroy();
    }

    private void WasColisionPresenter()
    {
        asteroidModel.CheckNeedSplite();
    }

    private void wasDestroyPresenter(GameObject gameObject)
    {
        asteroidWasDestroy?.Invoke(gameObject);
    }

    private void DestroyAsteroidPresenter(float time)
    {
        asteroidView.DestroyAsteroidView(time);
    }

    private void NeedSpliteAsteroidPresenter(Transform transform, float size)
    {
        needSplitAsteroid?.Invoke(transform, size);
    }

    private void InitializePresenter()
    {
        asteroidView.asteroidNeedMove += AsteroidNeedMovePresenter;
        asteroidView.whenDestroy += WhenDestroyPresenter;
        asteroidView.wasColision += WasColisionPresenter;
        asteroidView.wasDestroy += wasDestroyPresenter;
        asteroidView.UninitializePresenter += UninitializePresenter;

        asteroidModel.destroyAsteroid += DestroyAsteroidPresenter;
        asteroidModel.needSplitAsteroid += NeedSpliteAsteroidPresenter;
    }
    private void UninitializePresenter()
    {
        asteroidView.asteroidNeedMove -= AsteroidNeedMovePresenter;
        asteroidView.whenDestroy -= WhenDestroyPresenter;
        asteroidView.wasColision -= WasColisionPresenter;
        asteroidView.wasDestroy -= wasDestroyPresenter;
        asteroidView.UninitializePresenter -= UninitializePresenter;

        asteroidModel.destroyAsteroid -= DestroyAsteroidPresenter;
        asteroidModel.needSplitAsteroid -= NeedSpliteAsteroidPresenter;
    }
}
