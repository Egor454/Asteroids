
public class LaserPresenter : ILaserPresenter
{
    ILaserView laserView;
    ILaserModel laserModel;

    public LaserPresenter(ILaserView view, ILaserModel model)
    {
        laserView = view;
        laserModel = model;
        Initialize();
    }

    private void LaserActivatedPresenter()
    {
        laserModel.StartTimeLaserShoot();
    }

    private void LaserCantShootPresenter()
    {
        laserModel.StopWorkLaser();
    }

    private void StartLaserShootPresenter(int time)
    {
        laserView.StartTimerShoot(time);
    }

    private void Initialize()
    {
        laserView.laserActivated += LaserActivatedPresenter;
        laserView.laserCantShoot += LaserCantShootPresenter;
        laserModel.StartShoot += StartLaserShootPresenter;
        laserView.UninitializePresenter += Uninitialize;
    }
    private void Uninitialize()
    {
        laserView.laserActivated -= LaserActivatedPresenter;
        laserView.laserCantShoot -= LaserCantShootPresenter;
        laserModel.StartShoot -= StartLaserShootPresenter;
        laserView.UninitializePresenter -= Uninitialize;
    }

}
