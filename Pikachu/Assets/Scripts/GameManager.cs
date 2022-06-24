using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameState gameState;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        ChangeState(GameState.GenerateGrid);
    }

    public void ChangeState(GameState newState)
    {
        gameState = newState;
        switch (newState)
        {
            case GameState.GenerateGrid:
                break;
            case GameState.SpawnBall:
                break;
            case GameState.SpawnQueueBall:
                break;
            case GameState.StartTurn:
                break;
            case GameState.EndTurn:
                break;
            case GameState.Lose:
                break;
        }
    }
}

public enum GameState
{
    GenerateGrid = 0,
    SpawnBall = 1,
    SpawnQueueBall = 2,
    StartTurn = 3,
    EndTurn = 4,
    Lose = 5
}
