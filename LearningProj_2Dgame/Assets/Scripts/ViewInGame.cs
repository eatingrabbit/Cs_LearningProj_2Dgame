using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewInGame : MonoBehaviour
{
    public Text coinLabel;
    public Text scoreLabel;
    public Text highscoreLabel;

    //Update()함수는 프레임마다 불리기에 연산 능력이 낭비됨
    //->나중에는 값이 바뀔때만 텍스트가 바뀌도록 구현해야함.
    void Update()
    {
        if (GameManager.instance.currentGameState == GameState.inGame)
        {
            coinLabel.text = GameManager.instance.collectedCoins.ToString();
            scoreLabel.text = PlayerController.instance.GetDistance().ToString("f0");
            //f0 : 문자열 표시 형식->정수로만 표시하라는 뜻

            highscoreLabel.text = PlayerPrefs.GetFloat("highscore", 0).ToString("f0");
        }
    }
}
