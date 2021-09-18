using System;
using UnityEngine;

public class EnemyShipModel : IEnemyShipModel
{
    private Transform transform;
    private Transform transformTarget;

    private float speed = 1.0f;
    private float maxTimeLife = 35.0f;

    public event Action<float> destroyEnemyShip;

    public EnemyShipModel(Transform target, Transform transforms)
    {
        transform = transforms;
        transformTarget = target;
    }

    public void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, transformTarget.position, speed * Time.deltaTime);
    }

    public void Destroy()
    {
        destroyEnemyShip?.Invoke(maxTimeLife);
    }
}
