using UnityEngine;
using UnityEngine.Events;

public class BulletView : MonoBehaviour
{
    public UnityAction bulletIsMove;
    public UnityAction WhenDestroy;
    void Start()
    {
        WhenDestroy?.Invoke();
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
}
