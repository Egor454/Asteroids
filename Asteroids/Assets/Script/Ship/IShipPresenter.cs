using System;
public interface IShipPresenter
{
    event Action<float, int, float> sendDataPresenter;
    event Action shipWasDestroy;

    void TakeData();
}
