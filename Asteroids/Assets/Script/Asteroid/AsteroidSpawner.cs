using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private AsteroidView asteroidPrefab;
    [SerializeField] private float spawnDistance = 12.0f;
    [SerializeField] private float spawnRate = 3.0f;
    [SerializeField] private int amountPerSpawn = 1;
    [SerializeField] private int countForSplit = 2;
    [Range(0.0f, 45.0f)]
    [SerializeField] private float trajectoryVariance = 15.0f;

    private  new Transform transform;

    private void Start()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
        transform = GetComponent<Transform>();
    }

    public void Spawn()
    {
        for (int i = 0; i < amountPerSpawn; i++)
        {
            Vector2 spawnDirection = Random.insideUnitCircle.normalized;
            Vector3 spawnPoint = spawnDirection * spawnDistance;

            spawnPoint += this.transform.position;

            float variance = Random.Range(-trajectoryVariance, trajectoryVariance);
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);

            AsteroidView asteroid = Instantiate(asteroidPrefab, spawnPoint, rotation);
            AsteroidModel asteroidModel = new AsteroidModel(asteroid);
            asteroid.needSplitAsteroid += CreateSplit;

            asteroid.size = Random.Range(asteroid.minSize, asteroid.maxSize);

            Vector3 trajectory = rotation * -spawnDirection;
            asteroid.SetTrajectory(trajectory);
        }
    }

    private void CreateSplit(AsteroidView asteroidSplit, Transform transformSplitAsteroid, float sizeSplitAsteroid)
    {
        for(int i = 0; i < countForSplit; i++)
        {
            Vector2 position = transformSplitAsteroid.position;
            position += Random.insideUnitCircle * 0.5f;

            AsteroidView asteroidSmall = Instantiate(asteroidSplit, position, transformSplitAsteroid.rotation);
            AsteroidModel asteroidModel = new AsteroidModel(asteroidSmall);
            asteroidSmall.size = sizeSplitAsteroid * 0.5f;

            asteroidSmall.SetTrajectory(Random.insideUnitCircle.normalized);
        }
   
    }
}
