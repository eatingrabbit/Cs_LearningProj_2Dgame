using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillTrigger : MonoBehaviour
{
    //�ٸ� Collider�� �� Collider�� ���� �� ó�� 1�� ����Ƽ�� �ڵ����� �θ��� �Լ�
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerController.instance.Kill();
        }
    }
}
