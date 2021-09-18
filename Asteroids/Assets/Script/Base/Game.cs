using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour, IGame
{
    [SerializeField] private GameObject shipObj;
    [SerializeField] private GameObject massegeBoxGameOver;
    [SerializeField] private AsteroidSpawner asteroidSpawner;
    [SerializeField] private EnemyShipSpawner enemyShipSpawner;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text positionShip;
    [SerializeField] private Text rotationShip;
    [SerializeField] private Text speedShip;
    [SerializeField] private Text countLaserShip;
    [SerializeField] private Text timeReloudLaserShip;

    private Transform transformShip;
    private IAsteroidPresenter asteroid;
    private IEnemyShipPresenter enemyShip;
    private IShipPresenter shipPresenter;

    private int score;

    public void Initialization(IShipPresenter presenter)
    {
        shipPresenter = presenter;
        shipPresenter.sendDataPresenter += UpdateUI;
        shipPresenter.shipWasDestroy += GameOver;
    }
    private void Start()
    {
        transformShip = shipObj.gameObject.GetComponent<Transform>();

        asteroidSpawner.asteroidCreate += SetAsteroidData;
        enemyShipSpawner.enemyShipCreate += SetEnemyShipData;
    }

    private void Update()
    {
        shipPresenter.TakeData();
    }

    private void GameOver()
    {
        massegeBoxGameOver.SetActive(true);
        shipObj.SetActive(false);
        scoreText.text = score.ToString();

    }

    private void SetScore(GameObject obj)
    {
        if (obj.tag == "Asteroid")
        {
            score += 100;
        }
        else if (obj.tag == "EnemyShip")
        {
            score += 200;
        }
    }

    private void UpdateUI(float moveSpeed, int countLaserShoot, float timeReloudLaser)
    {
        positionShip.text = "X:" + Math.Round(transformShip.position.x, 2).ToString() + "Y:" + Math.Round(transformShip.position.y, 2).ToString();
        rotationShip.text = "Rot:" + Math.Round(transformShip.eulerAngles.z, 2).ToString();
        speedShip.text = "Speed:" + Math.Round(moveSpeed, 4).ToString();
        countLaserShip.text = "LaserShoot:" + countLaserShoot.ToString();
        timeReloudLaserShip.text = "TimeRel:" + Math.Round(timeReloudLaser, 0).ToString() + " sec";
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void SetAsteroidData(IAsteroidPresenter asteroidPresenter)
    {
        asteroid = asteroidPresenter;
        asteroidPresenter.asteroidWasDestroy += SetScore;

    }

    private void SetEnemyShipData(IEnemyShipPresenter enemyPresenter)
    {
        enemyShip = enemyPresenter;
        enemyShip.EnemyShipWasDestroy += SetScore;

    }
}
