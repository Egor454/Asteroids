using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyShipSpawner : MonoBehaviour
{

    [SerializeField] private EnemyShipView enemyShipPrefab;
    [SerializeField] private ShipView shipTarget;
    [SerializeField] private float spawnDistance = 12.0f;
    [SerializeField] private float spawnRate = 15.0f;
    [SerializeField] private int amountPerSpawn = 1;

    private new Transform transform;
    private Transform transformTarget;

    public UnityAction<EnemyShipView> enemyShipCrate;

    private void Start()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
        transform = GetComponent<Transform>();
        transformTarget = shipTarget.gameObject.GetComponent<Transform>();
    }

    public void Spawn()
    {
        for (int i = 0; i < amountPerSpawn; i++)
        {
            Debug.Log("spawn");
            Vector2 spawnDirection = Random.insideUnitCircle.normalized;
            Vector3 spawnPoint = spawnDirection * spawnDistance;

            spawnPoint += this.transform.position;

            EnemyShipView enemyShip = Instantiate(enemyShipPrefab, spawnPoint, transform.rotation);
            EnemyShipModel enemyShipModel = new EnemyShipModel(enemyShip,transformTarget);
            enemyShipCrate?.Invoke(enemyShip);
        }
    }

}
