using System;
using UnityEngine;

public interface IBulletModel
{
    event Action<float> DestroyBullet;

    void Move();
    void Destroy();
    void SetTransform(Transform transforms);
}
