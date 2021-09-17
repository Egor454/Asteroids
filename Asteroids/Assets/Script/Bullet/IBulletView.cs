using System;
using UnityEngine;

public interface IBulletView
{
    event Action bulletIsMove;
    event Action whenDestroy;
    event Action<Transform> setTransformPosition;
    event Action uninitializePresenter;

    void DestroyBulletView(float timeLife);
}
