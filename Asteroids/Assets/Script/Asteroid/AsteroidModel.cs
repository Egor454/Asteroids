using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AsteroidModel
{
    private AsteroidView asteroid;
    private Transform transform;

    private float movementSpeed = 1.0f;
    private float maxLifetime = 20.0f;
    private bool speedChanged = false;

    private float size;
    private float minSize;
    private float maxSize;

    public UnityAction<AsteroidView, Transform, float> needSplitAsteroid;

    public AsteroidModel(AsteroidView asteroidView,float needSize,float minNeedSize,float needMaxSize)
    {
        asteroid = asteroidView;
        transform = asteroidView.gameObject.GetComponent<Transform>();
        size = needSize;
        minSize = minNeedSize;
        maxSize = needMaxSize;

        asteroid.asteroidNeedMove += Move;
        asteroid.whenDestroy += Destroy;
        asteroid.wasColision += CheckNeedSplite;

        transform.eulerAngles = new Vector3(0.0f, 0.0f, Random.value * 360.0f);

        transform.localScale = Vector3.one * size;
    }

    private void Move(Vector3 direction)
    {
        if (!speedChanged)
        {
            ChangeSpeed();
        }
        transform.position += direction * movementSpeed * Time.deltaTime;
    }

    private void Destroy()
    {
        asteroid.DestroyAsteroidView(maxLifetime);
    }

    private void ChangeSpeed()
    {
        if (size < 1.0f)
        {
            movementSpeed = movementSpeed * 2;
            speedChanged = true;
        }
    }

    private void CheckNeedSplite()
    {
        if ((size * 0.5f) >= minSize)
        {
            needSplitAsteroid?.Invoke(asteroid,transform,size);
        }
    }

}
