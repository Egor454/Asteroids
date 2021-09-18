using System;
using UnityEngine;

public class BulletView : MonoBehaviour, IBulletView
{
    public event Action bulletIsMove;
    public event Action whenDestroy;
    public event Action<Transform> setTransformPosition;
    public event Action uninitializePresenter;

    void Start()
    {
        whenDestroy?.Invoke();
        setTransformPosition?.Invoke(this.gameObject.GetComponent<Transform>());

    }

    void FixedUpdate()
    {
        bulletIsMove?.Invoke();
    }
    public void DestroyBulletView(float timeLife)
    {
        Destroy(gameObject, timeLife);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Asteroid" || collision.gameObject.tag == "EnemyShip")
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        uninitializePresenter?.Invoke();
    }
}
