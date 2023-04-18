using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameState gameState;
    public EnemySpawner enemySpawner;
    [SerializeField] private int numberOfAliens;
    public GameObject enemyMartian;

    [SerializeField] private int numberOfCows;
    // Start is called before the first frame update
    void Awake()
    {
        enemySpawner.SpawnEnemy(enemyMartian);
        gameState = GameState.Gameplay;
        GameObject[] aliens = GameObject.FindGameObjectsWithTag("Alien");
        numberOfAliens = aliens.Length;
        GameObject[] cows = GameObject.FindGameObjectsWithTag("Cow");
        numberOfCows = cows.Length;
        Debug.Log("number of cows" + numberOfCows);
    }

    private void Update()
    {
      //  enemySpawner.SpawnEnemy();
    }

    // public Gamestate GetGameState()
    // {
    //     return gameState;
    // }

    public void AliensKilled()
    {
        
        gameState = GameState.Victory;

    }

    public void AllCowsKilled()
    {
          gameState = GameState.GameOver;
    }
}
