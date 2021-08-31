using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public static LevelGenerator instance;

    //û����-�̰����� level piece �����Ͽ� ��� //�����߿��� ����x
    public List<LevelPiece> levelPrefabs = new List<LevelPiece>();
    public Transform levelStartPoint;

    //���ӿ� ���Ǵ� ����� level piece�� �߰��Ǵ°� //���� ����Ǹ� �����
    public List<LevelPiece> pieces = new List<LevelPiece>();

    void Awake() { instance = this; }

    void Start() { for (int i = 0; i < 2; i++) { AddPiece(); } }

    //ó�� ���۽� LevelPiece 2�� ����
    public void GenerateInitialPieces()
    {
        foreach (LevelPiece piece in pieces)
        {
            Destroy(piece.gameObject);
        }
        pieces.Clear();
        for (int i = 0; i < 2; i++) { AddPiece(); }
    }

    //LevelPiece ������ ����-LeaveTrigger ��ũ��Ʈ�� ���� �Ҹ�
    public void AddPiece()
    {
        int randomIndex = Random.Range(0, levelPrefabs.Count);

        //levelPrefabs���� ���纻�� ����� piece ������ ���� -> ��ü�� ���纻�� �����ϴ� ���� �ν��Ͻ�ȭ
        LevelPiece piece = (LevelPiece)Instantiate(levelPrefabs[randomIndex]);

        //piece�� �θ� LevelGenerator GameObject�� ���� LevelGenerator�� ��ǥ�踦 �������� �ϵ�,
        //worldPositionStays�� false�� ���� ������ǥ�� �״��, �۷ι���ǥ�� �ٲ�Բ� ����
        piece.transform.SetParent(this.transform, false);

        Vector3 spawnPosition = Vector3.zero;

        if (pieces.Count == 0)
        {
            spawnPosition = levelStartPoint.position;
        }
        else
        {
            spawnPosition = pieces[pieces.Count - 1].exitPoint.position;
        }

        piece.transform.position = spawnPosition;
        pieces.Add(piece);
    }

    //������ LevelPiece ����-LeaveTrigger ��ũ��Ʈ�� ���� �Ҹ�
    public void RemoveOldestPiece()
    {
        LevelPiece oldestPiece = pieces[0];

        pieces.Remove(oldestPiece);

        //instantiate�� LevelPiece�� Destroy�� �̿��Ͽ� ������ �� ����.
        Destroy(oldestPiece.gameObject);
    }
}
