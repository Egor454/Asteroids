using UnityEngine;

public class EnemyShipModel
{
    private EnemyShipView enemyShip;
    private Transform transform;
    private Transform transformTarget;

    private float speed = 1.0f;
    private float maxTimeLife = 35.0f;

    public EnemyShipModel(EnemyShipView enemyShipView,Transform target)
    {
        enemyShip = enemyShipView;
        transform = enemyShip.gameObject.GetComponent<Transform>();
        transformTarget = target;

        enemyShip.enemyShipNeedMove += Move;
        enemyShip.whenDestroy += Destroy;
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, transformTarget.position, speed * Time.deltaTime);
    }
    
    private void Destroy()
    {
        enemyShip.DestroyEnemyShipView(maxTimeLife);
    }
}
