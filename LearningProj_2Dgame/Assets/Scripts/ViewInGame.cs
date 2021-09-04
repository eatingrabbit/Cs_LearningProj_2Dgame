using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewInGame : MonoBehaviour
{
    public Text coinLabel;
    public Text scoreLabel;
    public Text highscoreLabel;

    //Update()�Լ��� �����Ӹ��� �Ҹ��⿡ ���� �ɷ��� �����
    //->���߿��� ���� �ٲ𶧸� �ؽ�Ʈ�� �ٲ�� �����ؾ���.
    void Update()
    {
        if (GameManager.instance.currentGameState == GameState.inGame)
        {
            coinLabel.text = GameManager.instance.collectedCoins.ToString();
            scoreLabel.text = PlayerController.instance.GetDistance().ToString("f0");
            //f0 : ���ڿ� ǥ�� ����->�����θ� ǥ���϶�� ��

            highscoreLabel.text = PlayerPrefs.GetFloat("highscore", 0).ToString("f0");
        }
    }
}
