using System;
using UnityEngine;
public interface IAsteroidPresenter
{
    event Action<GameObject> asteroidWasDestroy;
    event Action<Transform, float> needSplitAsteroid;
}
