using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AsteroidView : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    private SpriteRenderer spriteRenderer;
    private new Transform transform;

    private Vector3 directionAsteroidMove;

    public UnityAction<Vector3> asteroidNeedMove;
    public UnityAction whenDestroy;
    public UnityAction wasColision;
    public UnityAction<GameObject> wasDestroy;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        transform = GetComponent<Transform>();
    }

    private void Start()
    {
        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];

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
            wasColision?.Invoke();
            wasDestroy?.Invoke(gameObject);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Laser")
        {
            wasDestroy?.Invoke(gameObject);
            Destroy(gameObject);
        }
    }

    public void DestroyAsteroidView(float time)
    {
        Destroy(gameObject, time);
    }
}
