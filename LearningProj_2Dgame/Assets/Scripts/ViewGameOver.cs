using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewGameOver : MonoBehaviour
{
    public Text coinLabel;
    public Text scoreLabel;

    public static ViewGameOver instance;

    void Awake() { instance = this; }

    public void ShowCoinsAndScore()
    {
        coinLabel.text = GameManager.instance.collectedCoins.ToString();
        scoreLabel.text = PlayerController.instance.GetDistance().ToString("f0");
    }
}
