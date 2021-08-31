using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public static LevelGenerator instance;

    //청사진-이곳에서 level piece 복사하여 사용 //게임중에도 변경x
    public List<LevelPiece> levelPrefabs = new List<LevelPiece>();
    public Transform levelStartPoint;

    //게임에 사용되는 복사된 level piece가 추가되는곳 //게임 진행되면 변경됨
    public List<LevelPiece> pieces = new List<LevelPiece>();

    void Awake() { instance = this; }

    void Start() { for (int i = 0; i < 2; i++) { AddPiece(); } }

    //처음 시작시 LevelPiece 2개 생성
    public void GenerateInitialPieces()
    {
        foreach (LevelPiece piece in pieces)
        {
            Destroy(piece.gameObject);
        }
        pieces.Clear();
        for (int i = 0; i < 2; i++) { AddPiece(); }
    }

    //LevelPiece 조각들 생성-LeaveTrigger 스크립트에 의해 불림
    public void AddPiece()
    {
        int randomIndex = Random.Range(0, levelPrefabs.Count);

        //levelPrefabs에서 복사본을 만들어 piece 변수에 대입 -> 객체의 복사본을 생성하는 것이 인스턴스화
        LevelPiece piece = (LevelPiece)Instantiate(levelPrefabs[randomIndex]);

        //piece의 부모를 LevelGenerator GameObject로 정해 LevelGenerator의 좌표계를 기준으로 하되,
        //worldPositionStays를 false로 정해 로컬좌표는 그대로, 글로벌좌표가 바뀌게끔 설정
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

    //오래된 LevelPiece 제거-LeaveTrigger 스크립트에 의해 불림
    public void RemoveOldestPiece()
    {
        LevelPiece oldestPiece = pieces[0];

        pieces.Remove(oldestPiece);

        //instantiate한 LevelPiece를 Destroy를 이용하여 제거할 수 있음.
        Destroy(oldestPiece.gameObject);
    }
}
