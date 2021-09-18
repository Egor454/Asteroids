using System;
using UnityEngine;
public interface IAsteroidModel
{
    event Action<Transform, float> needSplitAsteroid;
    event Action<float> destroyAsteroid;

    void Move();
    void Destroy();
    void CheckNeedSplite();
}
