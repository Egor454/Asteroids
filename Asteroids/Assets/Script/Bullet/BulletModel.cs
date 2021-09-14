using UnityEngine;

public class BulletModel
{
    private BulletView bullet;
    private Transform transform;
    private float speed = 30.0f;
    public float maxLifetime = 5.0f;

    public BulletModel(BulletView bulletView)
    {
        bullet = bulletView;
        bullet.bulletIsMove += Move;
        bullet.WhenDestroy += Destroy;

        transform = bullet.gameObject.GetComponent<Transform>();
    }

    public void Move()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }

    public void Destroy()
    {
        bullet.DestroyBulletView(maxLifetime);
    }
}
