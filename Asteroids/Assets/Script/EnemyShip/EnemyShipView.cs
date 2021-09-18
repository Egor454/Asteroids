using System;
using UnityEngine;

public class EnemyShipView : MonoBehaviour, IEnemyShipView
{
    public event Action enemyShipNeedMove;
    public event Action whenDestroy;
    public event Action<GameObject> wasDestroy;

    private void Start()
    {
        whenDestroy?.Invoke();
    }

    private void FixedUpdate()
    {
        enemyShipNeedMove?.Invoke();
    }

    public void DestroyEnemyShipView(float time)
    {
        Destroy(gameObject, time);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "Laser")
        {
            wasDestroy?.Invoke(gameObject);
            Destroy(gameObject);
        }

    }
}
