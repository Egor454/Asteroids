using UnityEngine;

public class TeleportShip : OutOfScreenCheck
{
    private void Start()
    {
        onObjectOutOfScreen += Teleport;
    }

    private void Teleport(OutOfScreenDirection direction)
    {
        switch (direction)
        {
            case OutOfScreenDirection.Top:
                transform.position -= new Vector3(0, cameraSize.y * 2 + spriteRenderer.bounds.size.y);
                break;
            case OutOfScreenDirection.Bottom:
                transform.position += new Vector3(0, cameraSize.y * 2 + spriteRenderer.bounds.size.y);
                break;
            case OutOfScreenDirection.Right:
                transform.position -= new Vector3(cameraSize.x * 2 + spriteRenderer.bounds.size.x, 0);
                break;
            case OutOfScreenDirection.Left:
                transform.position += new Vector3(cameraSize.x * 2 + spriteRenderer.bounds.size.x, 0);
                break;
        }
    }

    private void OnDestroy()
    {
        onObjectOutOfScreen -= Teleport;
    }
}