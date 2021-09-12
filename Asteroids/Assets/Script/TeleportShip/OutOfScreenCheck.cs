using System;
using UnityEngine;

public class OutOfScreenCheck : MonoBehaviour
{
    protected Vector2 cameraSize;
    protected SpriteRenderer spriteRenderer;
    protected new Transform transform;
    public Action<OutOfScreenDirection> onObjectOutOfScreen;
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        transform = GetComponent<Transform>();
        cameraSize = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
    }

    void Update()
    {
        if (transform.position.x - spriteRenderer.bounds.size.x / 2 > cameraSize.x)
            onObjectOutOfScreen(OutOfScreenDirection.Right);
        else if (transform.position.x + spriteRenderer.bounds.size.x / 2 < -cameraSize.x)
            onObjectOutOfScreen(OutOfScreenDirection.Left);
        else if (transform.position.y - spriteRenderer.bounds.size.y / 2 > cameraSize.y)
            onObjectOutOfScreen(OutOfScreenDirection.Top);
        else if (transform.position.y + spriteRenderer.bounds.size.y / 2 < -cameraSize.y)
            onObjectOutOfScreen(OutOfScreenDirection.Bottom);
    }
}

public enum OutOfScreenDirection
{
    Top, Bottom, Left, Right
}
