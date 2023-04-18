using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public GameState gameState;
    public EnemySpawnController enemySpawner;
    public int numberOfAliens;
    public EnemySpawnController enemySpawnController;
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
        Debug.Log("number of aliens " + numberOfAliens);
        if (numberOfAliens == 1)
        {
            WaveManager();
        }
    }
    //How can I use this function so I can check my gamestate in update?
    // public void GetGameState()
    // {
    //     return gameState;
    // }

    public void AliensKilled()
    {
        
        gameState = GameState.Victory;

    }
    //why cant I call my public int "numberOfAliens" here??
    //Wave Manager
    public void WaveManager()
    {
        enemySpawnController.SpawnEnemies(numEnemiesSpawn);
        numEnemiesSpawn += (numEnemiesSpawn / 2);
        
    }
    
    public void AllCowsKilled()
    {
          gameState = GameState.GameOver;
    }
}
