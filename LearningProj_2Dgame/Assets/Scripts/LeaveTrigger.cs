using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveTrigger : MonoBehaviour
{
    //�ٸ� Collider�� �� Collider�� ���� �� ó�� 1�� ����Ƽ�� �ڵ����� �θ��� �Լ�
    void OnTriggerEnter2D(Collider2D other)
    {
        LevelGenerator.instance.AddPiece();
        LevelGenerator.instance.RemoveOldestPiece();
    }
}
