using System;
using UnityEngine;

public class EnemyShipSpawner : MonoBehaviour
{
    [SerializeField] private EnemyShipView enemyShipPrefab;
    [SerializeField] private ShipView shipTarget;
    [SerializeField] private float spawnDistance = 12.0f;
    [SerializeField] private float spawnRate = 15.0f;
    [SerializeField] private int amountPerSpawn = 1;

    private new Transform transform;
    private Transform transformTarget;

    public Action<IEnemyShipPresenter> enemyShipCreate;

    private void Start()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
        transform = GetComponent<Transform>();
        transformTarget = shipTarget.gameObject.GetComponent<Transform>();
    }

    private void Spawn()
    {
        for (int i = 0; i < amountPerSpawn; i++)
        {
            Vector2 spawnDirection = UnityEngine.Random.insideUnitCircle.normalized;
            Vector3 spawnPoint = spawnDirection * spawnDistance;

            spawnPoint += transform.position;

            EnemyShipView enemyShipView = Instantiate(enemyShipPrefab, spawnPoint, transform.rotation);
            IEnemyShipModel enemyShipModel = new EnemyShipModel(transformTarget, enemyShipView.gameObject.GetComponent<Transform>());
            IEnemyShipPresenter enemyPresenter = new EnemyShipPresenter(enemyShipView, enemyShipModel);
            enemyShipCreate?.Invoke(enemyPresenter);
        }
    }

}
