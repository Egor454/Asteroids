using System;
using UnityEngine;

public class BulletModel : IBulletModel
{
    private BulletView bullet;
    private Transform transform;
    private float speed = 30.0f;
    private float maxLifetime = 5.0f;

    public event Action<float> DestroyBullet;

    public void SetTransform(Transform transforms)
    {
        transform = transforms;
    }

    public void Move()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }

    public void Destroy()
    {
        DestroyBullet?.Invoke(maxLifetime);
    }
}
