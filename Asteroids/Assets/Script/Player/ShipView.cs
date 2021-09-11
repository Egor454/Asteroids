using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class ShipView : MonoBehaviour
{
    private new Transform transform;

    public UnityAction shipStartMove;
    public UnityAction shipStartRotate;

    private bool shipIsMove = false;
    private bool shipIsRotate = false;

    public Vector2 directionOfRotation;
    void Start()
    {
        transform = this.GetComponent<Transform>();
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
        //Debug.Log(context);
    }

    private void Update()
    {
        if (shipIsMove)
        {
            shipStartMove?.Invoke();
        }
        if (shipIsRotate)
        {
            shipStartRotate?.Invoke();
        }
    }

    public void Rotation(InputAction.CallbackContext value)
    {
        shipIsRotate = true;
        directionOfRotation = value.ReadValue<Vector2>();
        Debug.Log(value);
    }

    public void Fire(InputAction.CallbackContext value)
    {
        Debug.Log(value);
    }

    public void MoveShipOnScreen(float speed)
    {
        transform.position += transform.up * speed;
        Debug.Log(speed);
    }
    public void RotateShipOnScreen(float rotate)
    {
        transform.Rotate(directionOfRotation.y * rotate, directionOfRotation.y * rotate, directionOfRotation.x * (-rotate));
        Debug.Log(rotate);
    }
}
