using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text waveText;
    [SerializeField] private TMP_Text cowCountText;
    private int waveCounterTMP;
    public GameState gameState;

    public Material firstSkyboxChange;
    public Material secondSkyboxChange;
    //number of rounds til win
    public int numOfRounds;
    [SerializeField] private int waveRound;
    public EnemySpawnController enemySpawner;
    //Count of amount of aliens in scene
    public int numberOfAliens;
    public AudioSource newWaveSound;
    private int startNumberOfCows;
    
    
    public EnemySpawnController enemySpawnController;
    //number of enemies to spawn at beginning
    [FormerlySerializedAs("enemyCount")] public int numEnemiesSpawn;

    [SerializeField] private int numberOfCows;
    // Start is called before the first frame update
    void Awake()
    {
        waveCounterTMP = numOfRounds;
        gameState = GameState.Gameplay;
        GameObject[] aliens = GameObject.FindGameObjectsWithTag("Enemy");
        numberOfAliens = aliens.Length;
        GameObject[] cows = GameObject.FindGameObjectsWithTag("Cow");
        startNumberOfCows = cows.Length;
        Debug.Log("starting cows " +startNumberOfCows);
    }

    private void Update()
    {
        Debug.Log("current cows" + numberOfCows);
        // if (sceneTestChange == 1)
        // {
        //     SkyboxChange(skyboxChange);
        // }
        if (numberOfCows <= startNumberOfCows / 2)
        {
            SkyboxChange(firstSkyboxChange);
        }

        if (numberOfCows <= startNumberOfCows / 4)
        {
            SkyboxChange(secondSkyboxChange);
        }
            
        cowCountText.text = (numberOfCows +" Cows Left" );
        
        //GetGameState();
        GameObject[] aliens = GameObject.FindGameObjectsWithTag("Enemy");
        numberOfAliens = aliens.Length;
        GameObject[] cows = GameObject.FindGameObjectsWithTag("Cow");
        numberOfCows = cows.Length;
        if (numberOfAliens == 1)
        {
            waveRound += 1;
            waveCounterTMP -= 1;
            waveText.text = ("Wave :" + waveCounterTMP);
            WaveManager();
        }

        if (waveRound == numOfRounds)
        {
            WavesComplete();
        }

        if (numberOfCows ==0)
        {
            AllCowsKilled();
        }
    }
    //How can I use this function so I can check my gamestate in update?
    // public void GetGameState()
    // {
    //     return gameState;
    // }

    public void WavesComplete()
    {
        gameState = GameState.Victory;
        //numEnemiesSpawn = 0;
        SceneManager.LoadScene("Win Scene");

        //Script to teleport you to victory

    }
    //why cant I call my public int "numberOfAliens" here??
    //Wave Manager
    public void WaveManager()
    {
        enemySpawnController.SpawnEnemies(numEnemiesSpawn);
        numEnemiesSpawn += (numEnemiesSpawn / 2);
        newWaveSound.Play();

    }

    public void SkyboxChange(Material skybox)
    {
        RenderSettings.skybox = skybox;
    }
    public void AllCowsKilled()
    {
          gameState = GameState.GameOver;
          //script to teleport u to L screen
          SceneManager.LoadScene("Lose Scene");
    }
}
