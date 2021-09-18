using System;
using UnityEngine;
public interface IAsteroidView
{
    event Action asteroidNeedMove;
    event Action whenDestroy;
    event Action wasColision;
    event Action<GameObject> wasDestroy;
    event Action UninitializePresenter;

    void DestroyAsteroidView(float time);
}
