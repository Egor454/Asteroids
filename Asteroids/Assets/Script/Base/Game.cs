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
    [SerializeField] private EngineShip ship;
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



    public void Initialization(EngineShip ships)
    {
        ship = ships;
        ship.shipDestroy += GameOver;
    }
    private void Start()
    {
        transformShip = shipObj.gameObject.GetComponent<Transform>();

        asteroidSpawner.asteroidCrate += SetAsteroidData;
        enemyShipSpawner.enemyShipCrate += SetEnemyShipData;
    }

    private void Update()
    {
        UpdateUI();
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

    private void UpdateUI()
    {
        positionShip.text = "X:" + Math.Round(transformShip.position.x, 2).ToString() + "Y:" + Math.Round(transformShip.position.y, 2).ToString();
        rotationShip.text = "Rot:" + transformShip.eulerAngles.z.ToString();
        speedShip.text = "Speed:" + Math.Round(ship.MoveSpeed,4).ToString();
        countLaserShip.text = "LaserShoot:" + ship.CountShootLaser.ToString();
        timeReloudLaserShip.text = "TimeRel:" + Math.Round(ship.TimePassedText,0).ToString() + " sec";
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
