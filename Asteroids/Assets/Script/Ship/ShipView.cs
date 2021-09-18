using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShipView : MonoBehaviour, IShipView
{
    [SerializeField] private BulletView bulletPrefab;
    [SerializeField] private GameObject laserPrefab;

    private new Transform transform;

    public event Action shipStartMove;
    public event Action<Vector3> shipStartRotate;
    public event Action shipStopMove;
    public event Action checkLaserCountShoot;
    public event Action<IBulletView> shipShootBullet;
    public event Action<GameObject> shipShootLaser;
    public event Action haveCollision;
    public event Action UninitializePresenter;

    private bool shipIsMove = false;
    private bool shipIsRotate = false;

    private Vector2 directionOfRotation;

    void Start()
    {
        transform = this.GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        checkLaserCountShoot?.Invoke();
        if (shipIsMove)
        {
            shipStartMove?.Invoke();
        }
        else
        {
            shipStopMove?.Invoke();
        }

        if (shipIsRotate)
        {
            shipStartRotate?.Invoke(directionOfRotation);
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            shipIsMove = true;
        }
        else
        {
            shipIsMove = false;
        }
    }

    public void Rotation(InputAction.CallbackContext value)
    {
        if (value.performed)
        {
            shipIsRotate = true;
        }
        else
        {
            shipIsRotate = false;
        }
        directionOfRotation = value.ReadValue<Vector2>();
    }

    public void FireBullet(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            IBulletView bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            shipShootBullet?.Invoke(bullet);
        }
    }

    public void FireLaser(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            shipShootLaser?.Invoke(laserPrefab);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Asteroid" || collision.gameObject.tag == "EnemyShip")
        {
            haveCollision();
        }
    }

    private void OnDestroy()
    {
        UninitializePresenter?.Invoke();
    }
}
