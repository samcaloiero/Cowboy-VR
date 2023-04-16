using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameState gameState;
    // Start is called before the first frame update
    void Start()
    {
           Debug.Log(gameState);
        gameState = GameState.Gameplay;
    }


    // public Gamestate GetGameState()
    // {
    //     return gameState;
    // }

    private void AliensKilled()
    {

        gameState = GameState.Victory;

    }

    private void CowsKilled()
    {
          gameState = GameState.GameOver;
    }
}
