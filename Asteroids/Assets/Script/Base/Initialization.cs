using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initialization : MonoBehaviour
{
    [SerializeField] GameObject shipObg;

    void Start()
    {
        var shipView = shipObg.GetComponent<ShipView>();
        EngineShip engineShip = new EngineShip(shipView);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
