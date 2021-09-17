using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] private GameObject shipObj;
    [SerializeField] private GameObject massegeBoxGameOver;
    [SerializeField] private AsteroidSpawner asteroidSpawner;
    [SerializeField] private EnemyShipSpawner enemyShipSpawner;
    [SerializeField] private IShipPresenter shipPresenter;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text positionShip;
    [SerializeField] private Text rotationShip;
    [SerializeField] private Text speedShip;
    [SerializeField] private Text countLaserShip;
    [SerializeField] private Text timeReloudLaserShip;

    private Transform transformShip;
    private AsteroidView asteroid;
    private EnemyShipView enemyShip;

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

        asteroidSpawner.asteroidCrate += SetAsteroidData;
        enemyShipSpawner.enemyShipCrate += SetEnemyShipData;
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
        if(obj.tag == "Asteroid")
        {
            score += 100;
        }
        else if(obj.tag == "EnemyShip")
        {
            score += 200;
        }
    }

    private void UpdateUI(float moveSpeed, int countLaserShoot,float timeReloudLaser)
    {
        positionShip.text = "X:" + Math.Round(transformShip.position.x, 2).ToString() + "Y:" + Math.Round(transformShip.position.y, 2).ToString();
        rotationShip.text = "Rot:" + Math.Round(transformShip.eulerAngles.z,2).ToString();
        speedShip.text = "Speed:" + Math.Round(moveSpeed, 4).ToString();
        countLaserShip.text = "LaserShoot:" + countLaserShoot.ToString();
        timeReloudLaserShip.text = "TimeRel:" + Math.Round(timeReloudLaser, 0).ToString() + " sec";
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void SetAsteroidData(AsteroidView asteroidView)
    {
        asteroid = asteroidView;
        asteroid.wasDestroy += SetScore;

    }

    private void SetEnemyShipData(EnemyShipView enemyShipView)
    {
        enemyShip = enemyShipView;
        enemyShip.wasDestroy += SetScore;

    }
}
