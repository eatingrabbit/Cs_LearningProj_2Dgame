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
        currentGameState = GameState.menu;
        SetGameState(GameState.menu);
    }

    /*void Update()
    {
        if (Input.GetButtonDown("s"))
        {
            StartGame();
        }
    }
    */


    public Canvas menuCanvas;
    public Canvas inGameCanvas;
    public Canvas gameOverCanvas;

    public int collectedCoins = 0;

    //called to start the game
    public void StartGame()
    {
        //���Ǽ���-�ٽý��� �� ���� �ʱ�ȭ
        collectedCoins = 0;
        LevelGenerator.instance.GenerateInitialPieces();
        PlayerController.instance.StartGame();
        SetGameState(GameState.inGame);
    }

    //called when player die
    public void GameOver()
    {
        ViewGameOver.instance.ShowCoinsAndScore();
        SetGameState(GameState.gameOver);
    }

    //called when player decide to go back to the menu
    public void BackToMenu()
    {
        SetGameState(GameState.menu);
    }

    void SetGameState(GameState newGameState)
    {
        if (newGameState == GameState.menu)
        {
            //setup Unity scene for menu state
            menuCanvas.enabled = true;
            inGameCanvas.enabled = false;
            gameOverCanvas.enabled = false;
        }
        else if (newGameState == GameState.inGame)
        {
            //setup Unity scene for inGame state
            menuCanvas.enabled = false;
            inGameCanvas.enabled = true;
            gameOverCanvas.enabled = false;
        }
        else if (newGameState == GameState.gameOver)
        {
            //setup Unity scene for gameOver state
            menuCanvas.enabled = false;
            inGameCanvas.enabled = false;
            gameOverCanvas.enabled = true;
        }

        currentGameState = newGameState;
    }

    public void CollectedCoin()
    {
        collectedCoins ++;
    }
    
}
