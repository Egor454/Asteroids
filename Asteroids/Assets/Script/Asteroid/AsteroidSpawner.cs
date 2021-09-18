using UnityEngine;
using UnityEngine.Events;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private AsteroidView asteroidPrefab;
    [SerializeField] private float spawnDistance = 12.0f;
    [SerializeField] private float spawnRate = 3.0f;
    [SerializeField] private int amountPerSpawn = 1;
    [SerializeField] private int countForSplit = 2;
    [Range(0.0f, 45.0f)]
    [SerializeField] private float trajectoryVariance = 15.0f;
    [SerializeField] private float size;
    [SerializeField] private float minSize = 0.35f;
    [SerializeField] private float maxSize = 1.65f;

    private new Transform transform;

    public UnityAction<IAsteroidPresenter> asteroidCreate;

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

            spawnPoint += transform.position;

            float variance = Random.Range(-trajectoryVariance, trajectoryVariance);
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);

            AsteroidView asteroid = Instantiate(asteroidPrefab, spawnPoint, rotation);
            size = Random.Range(minSize, maxSize);
            Vector3 trajectory = rotation * -spawnDirection;
            IAsteroidModel asteroidModel = new AsteroidModel(asteroid.gameObject.GetComponent<Transform>(), trajectory, size, minSize, maxSize);
            IAsteroidPresenter asteroidPresenter = new AsteroidPresenter(asteroid, asteroidModel);
            asteroidPresenter.needSplitAsteroid += CreateSplit;
            asteroidCreate?.Invoke(asteroidPresenter);

        }
    }

    private void CreateSplit(Transform transformSplitAsteroid, float sizeSplitAsteroid)
    {
        for (int i = 0; i < countForSplit; i++)
        {
            Vector2 position = transformSplitAsteroid.position;
            position += Random.insideUnitCircle * 0.5f;

            AsteroidView asteroidSmall = Instantiate(asteroidPrefab, position, transformSplitAsteroid.rotation);
            size = sizeSplitAsteroid * 0.5f;
            IAsteroidModel asteroidModel = new AsteroidModel(asteroidSmall.gameObject.GetComponent<Transform>(), Random.insideUnitCircle.normalized, size, minSize, maxSize);
            IAsteroidPresenter asteroidPresenter = new AsteroidPresenter(asteroidSmall, asteroidModel);
            asteroidPresenter.needSplitAsteroid += CreateSplit;
            asteroidCreate?.Invoke(asteroidPresenter);
        }

    }
}
