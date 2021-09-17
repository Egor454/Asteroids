using UnityEngine;

public class Initialization : MonoBehaviour
{
    [SerializeField] GameObject shipObg;
    [SerializeField] Game game;

    void Awake()
    {
        IShipView shipView = shipObg.GetComponent<ShipView>();
        IShipModel shipModel = new ShipModel(shipObg.gameObject.transform, shipObg.GetComponent<Timer>());
        IShipPresenter shipPresenter = new ShipPresenter(shipView, shipModel);
        game.Initialization(shipPresenter);
    }
}
