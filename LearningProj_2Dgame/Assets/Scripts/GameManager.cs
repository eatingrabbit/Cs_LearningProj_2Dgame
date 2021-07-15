using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    menu,
    inGame,
    gameOver
}

public class GameManager : MonoBehaviour
{
    public GameState currentGameState = GameState.menu;

    //singleton pattern:  static class&variable �̿��Ͽ� Ŭ������ �ν��Ͻ��� �ϳ��� �����Ͽ�,
    //                      �ٸ� ������ �� Ŭ������ �ν��Ͻ��� �����ϸ� ���� �ҷȴ� �ϳ��� �ν��Ͻ��� ���� ����Ͽ�
    //                      ���α׷� ���� �� Ŭ������ �ν��Ͻ��� �ϳ��� �ν��Ͻ��� ���� �����ϴ� ���
    public static GameManager instance;
        //static class & static variable (=���� Ŭ���� & ���� ����)-> ���α׷� ����� ����Ǿ� ���� ��� ����, ���α׷� ������ �ı���
    
    void Awake()
    {
        instance = this;
    }
    //���� �ٸ� ������ GameManager �ν��Ͻ��� ������ �޼ҵ忡 ������ ��
    //GameManager(Ŭ�������� ��ũ��Ʈ �̸�).instance(GameManager Ŭ������ �ν��Ͻ�).variablesOrMethods�� ���ٰ���

    void Start()
    {
        StartGame();
    }

    //called to start the game
    void StartGame()
    {
        SetGameState(GameState.inGame);
    }

    //called when player die
    void GameOver()
    {
        SetGameState(GameState.gameOver);
    }

    //called when player decide to go back to the menu
    void BackToMenu()
    {
        SetGameState(GameState.menu);
    }

    void SetGameState(GameState newGameState)
    {
        if (newGameState == GameState.menu)
        {
            //setup Unity scene for menu state
        }
        else if (newGameState == GameState.inGame)
        {
            //setup Unity scene for inGame state
        }
        else if (newGameState == GameState.gameOver)
        {
            //setup Unity scen for gameOver state
        }
    }
}
