using System;
using UnityEngine;

public class AsteroidModel : IAsteroidModel
{
    private Transform transform;

    private float movementSpeed = 1.0f;
    private float maxLifetime = 20.0f;
    private bool speedChanged = false;

    private float size;
    private float minSize;
    private float maxSize;

    private Vector3 direction;

    public event Action<Transform, float> needSplitAsteroid;
    public event Action<float> destroyAsteroid;

    public AsteroidModel(Transform transforms, Vector3 directionAsteroidMove, float needSize, float minNeedSize, float needMaxSize)
    {
        size = needSize;
        minSize = minNeedSize;
        maxSize = needMaxSize;
        direction = directionAsteroidMove;
        transform = transforms;

        transform.eulerAngles = new Vector3(0.0f, 0.0f, UnityEngine.Random.value * 360.0f);

        transform.localScale = Vector3.one * size;
    }

    public void Move()
    {
        if (!speedChanged)
        {
            ChangeSpeed();
        }
        transform.position += direction * movementSpeed * Time.deltaTime;
    }

    public void Destroy()
    {
        destroyAsteroid?.Invoke(maxLifetime);
    }

    private void ChangeSpeed()
    {
        if (size < 0.5f)
        {
            movementSpeed = movementSpeed * 4;
            speedChanged = true;
        }
        else if (size < 1.0f && size > 0.5f)
        {
            movementSpeed = movementSpeed * 2;
            speedChanged = true;
        }

    }

    public void CheckNeedSplite()
    {
        if ((size * 0.5f) >= minSize)
        {
            needSplitAsteroid?.Invoke(transform, size);
        }
    }

}
