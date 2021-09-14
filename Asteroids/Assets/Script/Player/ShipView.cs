using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class ShipView : MonoBehaviour
{
    [SerializeField] private BulletView bulletPrefab;
    [SerializeField] private GameObject laserPrefab;

    private new Transform transform;

    public UnityAction shipStartMove;
    public UnityAction<Vector3> shipStartRotate;
    public UnityAction shipStopMove;
    public UnityAction laserReloud;
    public UnityAction checkLaserCountShoot;

    public UnityAction<BulletView> shipShootBullet;
    public UnityAction<GameObject> shipShootLaser;
    public UnityAction haveCollision;

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
            BulletView bullet = Instantiate(bulletPrefab,transform.position,transform.rotation);
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
            haveCollision?.Invoke();
        }
    }
}
