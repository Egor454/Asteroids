using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletModel
{
    private BulletView bullet;
    private float speed = 30.0f;
    public float maxLifetime = 5.0f;

    public BulletModel(BulletView bulletView)
    {
        bullet = bulletView;
        bullet.bulletIsMove += Move;
        bullet.WhenDestroy += Destroy;
    }

    public void Move(Transform transform)
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }

    public void Destroy()
    {
        bullet.DestroyBulletView(maxLifetime);
    }
}
