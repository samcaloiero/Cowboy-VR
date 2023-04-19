using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public GameState gameState;
    //number of rounds
    public int numOfRounds;
    [SerializeField] private int waveRound;
    public EnemySpawnController enemySpawner;
    //Count of amount of aliens in scene
    public int numberOfAliens;
    public AudioSource newWaveSound;
    
    public EnemySpawnController enemySpawnController;
    //number of enemies to spawn at beginning
    [FormerlySerializedAs("enemyCount")] public int numEnemiesSpawn;

    [SerializeField] private int numberOfCows;
    // Start is called before the first frame update
    void Awake()
    {
        gameState = GameState.Gameplay;
        GameObject[] aliens = GameObject.FindGameObjectsWithTag("Enemy");
        numberOfAliens = aliens.Length;
        GameObject[] cows = GameObject.FindGameObjectsWithTag("Cow");
        numberOfCows = cows.Length;
       
    }

    private void Update()
    {
        //GetGameState();
        GameObject[] aliens = GameObject.FindGameObjectsWithTag("Enemy");
        numberOfAliens = aliens.Length;
        GameObject[] cows = GameObject.FindGameObjectsWithTag("Cow");
        numberOfCows = cows.Length;
        if (numberOfAliens == 1)
        {
            waveRound += 1;
            WaveManager();
        }

        // if (waveRound == numOfRounds)
        // {
        //     WavesComplete();
        // }

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
        numEnemiesSpawn = 0;
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
    
    public void AllCowsKilled()
    {
          gameState = GameState.GameOver;
          //script to teleport u to L screen
    }
}
