using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AsteroidView : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    private SpriteRenderer spriteRenderer;
    private new Transform transform;

    public float size = 1.0f;
    public float minSize = 0.35f;
    public float maxSize = 1.65f;

    private Vector3 directionAsteroidMove;

    public UnityAction<Vector3> asteroidNeedMove;
    public UnityAction whenDestroy;
    public UnityAction<AsteroidView,Transform,float> needSplitAsteroid;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        transform = GetComponent<Transform>();
    }

    private void Start()
    {
        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
        transform.eulerAngles = new Vector3(0.0f, 0.0f, Random.value * 360.0f);

        transform.localScale = Vector3.one * size;

        whenDestroy?.Invoke();
    }

    private void FixedUpdate()
    {
        asteroidNeedMove?.Invoke(directionAsteroidMove);
    }

    public void SetTrajectory(Vector3 direction)
    {
        directionAsteroidMove = direction;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            if ((size * 0.5f) >= minSize)
            {
                needSplitAsteroid?.Invoke(this, transform, size);
            }

            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Laser")
        {
            Destroy(gameObject);
        }
    }

    public void DestroyAsteroidView(float time)
    {
        Destroy(gameObject, time);
    }
}
