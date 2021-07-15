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

    //singleton pattern:  static class&variable 이용하여 클래스의 인스턴스를 하나로 제한하여,
    //                      다른 곳에서 그 클래스의 인스턴스를 선언하면 원래 불렸던 하나의 인스턴스를 누적 사용하여
    //                      프로그램 내의 그 클래스의 인스턴스를 하나의 인스턴스로 전부 실행하는 방법
    public static GameManager instance;
        //static class & static variable (=정적 클래스 & 정적 변수)-> 프로그램 실행시 선언되어 누적 사용 가능, 프로그램 끝나면 파괴됨
    
    void Awake()
    {
        instance = this;
    }
    //이제 다른 곳에서 GameManager 인스턴스의 변수나 메소드에 접근할 때
    //GameManager(클래스이자 스크립트 이름).instance(GameManager 클래스의 인스턴스).variablesOrMethods로 접근가능

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
