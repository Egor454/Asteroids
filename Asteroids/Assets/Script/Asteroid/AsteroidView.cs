using System;
using UnityEngine;

public class AsteroidView : MonoBehaviour, IAsteroidView
{
    [SerializeField] private Sprite[] sprites;
    private SpriteRenderer spriteRenderer;

    public event Action asteroidNeedMove;
    public event Action whenDestroy;
    public event Action wasColision;
    public event Action<GameObject> wasDestroy;
    public event Action UninitializePresenter;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        spriteRenderer.sprite = sprites[UnityEngine.Random.Range(0, sprites.Length)];

        whenDestroy?.Invoke();
    }

    private void FixedUpdate()
    {
        asteroidNeedMove?.Invoke();
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
    private void OnDestroy()
    {
        UninitializePresenter?.Invoke();
    }
}
