using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public float jumpForce = 6f;
    public Animator animator;
    public float runningSpeed = 1.5f;
    
    private Rigidbody2D rigidBody;
    private Vector3 startingPosition;

    void Awake()
    {
        instance = this;

        rigidBody = GetComponent<Rigidbody2D>();
        startingPosition = this.transform.position;

    }
    public void StartGame()
    {
        animator.SetBool("isAlive", true);
        this.transform.position = startingPosition;

        //임의설정-다시시작 시 속도 초기화
        rigidBody.velocity = new Vector2(runningSpeed, 0);
        
    }
    void Update()
    {
        if (GameManager.instance.currentGameState == GameState.inGame)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Jump();
            }
            animator.SetBool("isGrounded", IsGrounded());
        }
    }
    void FixedUpdate()
    {
        if (GameManager.instance.currentGameState == GameState.inGame)
        {
            if (rigidBody.velocity.x < runningSpeed)
            {
                rigidBody.velocity = new Vector2(runningSpeed, rigidBody.velocity.y);
            }
        }
    }

    void Jump()
    {
        if (IsGrounded())
        {
            rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
    public LayerMask groundLayer;

    bool IsGrounded()
    {
        if (Physics2D.Raycast(this.transform.position, Vector2.down, 0.2f, groundLayer.value))
        {
            return true;
        }
        else { return false; }
    }

    public void Kill()
    {
        GameManager.instance.GameOver();
        animator.SetBool("isAlive", false);
        rigidBody.velocity = new Vector2(0.0f, 0.0f);

        //PlayerPrefs.GetFloat("string key",default float Value)
        //: 유니티가 string key로 기억한 float값을 불러오고, 만약 string key가 등록되지 않았다면 defaultValue를 불러옴.
        if (PlayerPrefs.GetFloat("highscore", 0) < this.GetDistance())
        {
            //PlayerPrefs.SetFloat("string key", float Value): 유니티가 string key로 float value를 기억하도록 설정함.
            PlayerPrefs.SetFloat("highscore", this.GetDistance());
        }
    }

    //지금까지 달려온 거리 계산
    public float GetDistance()
    {
        float traveledDistance = Vector2.Distance(new Vector2(startingPosition.x, 0), new Vector2(this.transform.position.x, 0));
        return traveledDistance;
    }
}
