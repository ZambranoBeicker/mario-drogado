using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EGameState
{
    menu, inGame, gameOver
}

public class GameManager : MonoBehaviour
{
    public EGameState CurrentGameState = EGameState.menu;
    public static GameManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        
    }
    private void Update()
    {
        
    }
    public void Menu()
    {
        SetGameState(EGameState.menu);
    }
    public void StarGame()
    {
        SetGameState(EGameState.inGame);
    }

    public void GameOver()
    {
        SetGameState(EGameState.gameOver);
    }
    private void SetGameState(EGameState newGameState)
    {
        if (newGameState == EGameState.menu)
        {

        }
        else if (newGameState == EGameState.inGame)
        {

        }
        else if (newGameState == EGameState.gameOver)
        {

        }

        this.CurrentGameState = newGameState;
    }
}
