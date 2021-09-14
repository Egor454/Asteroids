using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initialization : MonoBehaviour
{
    [SerializeField] GameObject shipObg;
    [SerializeField] Game game;

    void Start()
    {
        var shipView = shipObg.GetComponent<ShipView>();
        EngineShip engineShip = new EngineShip(shipView);
        game.Initialization(engineShip);
    }

    void Update()
    {
        
    }
}
