using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BulletView : MonoBehaviour
{
    public UnityAction<Transform> bulletIsMove;
    public UnityAction WhenDestroy;
    private new Transform transform;
    void Start()
    {
        transform = GetComponent<Transform>();
        WhenDestroy?.Invoke();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bulletIsMove?.Invoke(transform);
    }
    public void DestroyBulletView(float timeLife)
    {
        Destroy(this.gameObject, timeLife);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Asteroid" || collision.gameObject.tag == "EnemyShip")
        {
            Destroy(gameObject);
        }
    }
}
