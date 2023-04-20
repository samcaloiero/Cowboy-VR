using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreenManager : MonoBehaviour
{
    public GameState gameState;
    public int numberOfAliens;
    public SceneController sceneManager;


    private void Awake()
    {
        GameObject[] aliens = GameObject.FindGameObjectsWithTag("Enemy");
        numberOfAliens = aliens.Length;
        Debug.Log("There are " + numberOfAliens + " aliens in the scene.");
    }

    private void Update()
    {
        GameObject[] aliens = GameObject.FindGameObjectsWithTag("Enemy");
        numberOfAliens = aliens.Length;
        if (numberOfAliens <= 0)
        {
            sceneManager.GoToGameScene();
            
        }
    }
}
