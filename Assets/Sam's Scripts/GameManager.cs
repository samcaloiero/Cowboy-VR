using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameState gameState;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Gamestate GetGameState()
    {
        return gameState;
    }

    private void AliensKilled()
    {

        gameState = GameState.Victory;

    }

    private void CowsKilled()
    {
        gameState = new GameState.GameOver;
    }
}
