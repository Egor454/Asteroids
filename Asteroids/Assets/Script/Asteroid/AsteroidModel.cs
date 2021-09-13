using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidModel
{
    private AsteroidView asteroid;
    private Transform transform;

    private float movementSpeed = 1.0f;
    private float maxLifetime = 15.0f;
    private bool speedChanged = false;

    public AsteroidModel(AsteroidView asteroidView)
    {
        asteroid = asteroidView;
        transform = asteroidView.gameObject.GetComponent<Transform>();

        asteroid.asteroidNeedMove += Move;
        asteroid.whenDestroy += Destroy;
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
        if (asteroid.size < 1.0f)
        {
            movementSpeed = movementSpeed * 2;
            speedChanged = true;
        }
    }
}
