using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameState gameState;
    public EnemySpawnController enemySpawner;
    public int numberOfAliens;
    public EnemySpawnController enemySpawnController;
    public int enemyCount;

    [SerializeField] private int numberOfCows;
    // Start is called before the first frame update
    void Awake()
    {
        gameState = GameState.Gameplay;
        GameObject[] aliens = GameObject.FindGameObjectsWithTag("Alien");
        numberOfAliens = aliens.Length;
        GameObject[] cows = GameObject.FindGameObjectsWithTag("Cow");
        numberOfCows = cows.Length;
        Debug.Log("number of cows" + numberOfCows);
    }

    private void Update()
    {
        //GetGameState();
        GameObject[] aliens = GameObject.FindGameObjectsWithTag("Alien");
        numberOfAliens = aliens.Length;
        GameObject[] cows = GameObject.FindGameObjectsWithTag("Cow");
        numberOfCows = cows.Length;
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
        enemySpawnController.SpawnEnemies(enemyCount);
        enemyCount += (enemyCount / 2);
        
    }
    
    public void AllCowsKilled()
    {
          gameState = GameState.GameOver;
    }
}
