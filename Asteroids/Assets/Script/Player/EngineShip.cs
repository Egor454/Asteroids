using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EngineShip
{
    private ShipView shipView;
    private float speed = 0.1f;
    private float acceleration = 0.02f;
    private float moveSpeed = 0;
    private float constantAcceleration = 0.01f;
    private float speedRotate = 0.5f;

    public EngineShip(ShipView shipview)
    {
        this.shipView = shipview;

        shipView.shipStartMove += MoveShip;
        shipView.shipStartRotate += RotateShip;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void MoveShip()
    {
        moveSpeed = (speed + acceleration) * Time.deltaTime;
        acceleration = acceleration + constantAcceleration;
        shipView.MoveShipOnScreen(moveSpeed);

    }
    private void RotateShip()
    {
        shipView.RotateShipOnScreen(speedRotate);
    }
}
