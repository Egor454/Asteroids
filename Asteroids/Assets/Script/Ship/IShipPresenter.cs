using System;
using UnityEngine;
public interface IShipPresenter 
{
    event Action<float, int, float> sendDataPresenter;
    event Action shipWasDestroy;

    void TakeData();
}
