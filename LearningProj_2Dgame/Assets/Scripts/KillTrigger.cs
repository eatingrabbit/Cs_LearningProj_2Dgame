using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillTrigger : MonoBehaviour
{
    //다른 Collider가 이 Collider에 들어가면 들어간 처음 1번 유니티가 자동으로 부르는 함수
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerController.instance.Kill();
        }
    }
}
