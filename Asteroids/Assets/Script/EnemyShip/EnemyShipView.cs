using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyShipView : MonoBehaviour
{

    public UnityAction enemyShipNeedMove;
    public UnityAction whenDestroy;
    public UnityAction<GameObject> wasDestroy;

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
