using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public enum SIDE { Left, Mid, Right }

public class PlayerMovement : MonoBehaviour
{
    public SIDE m_Side = SIDE.Mid;
    float NewXPos = 0f;
    public bool MoveLeft;
    public bool MoveRight;
    public bool MoveUp;
    public bool isGrounded;
    public float XValue;
    private CharacterController characControl;
    private GameManager gameManager;

    private float y;
    private float x;
    public float JumpPower = 7f;
    public bool InJump;
    public float SpeedDodge;

    public float life;

    // Start is called before the first frame update
    void Start()
    {
        characControl = GetComponent<CharacterController>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        life = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.gameIsRunning == true)
        {
            MoveLeft = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow);
            MoveRight = Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow);
            MoveUp = Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow);
            if (MoveLeft)
            {
                if (m_Side == SIDE.Mid)
                {
                    NewXPos = -XValue;
                    m_Side = SIDE.Left;
                }
                else if (m_Side == SIDE.Right)
                {
                    NewXPos = 0;
                    m_Side = SIDE.Mid;
                }
            }
            else if (MoveRight)
            {
                if (m_Side == SIDE.Mid)
                {
                    NewXPos = XValue;
                    m_Side = SIDE.Right;
                }
                else if (m_Side == SIDE.Left)
                {
                    NewXPos = 0;
                    m_Side = SIDE.Mid;
                }
            }
            Vector3 moveVector = new Vector3(x - transform.position.x, y * Time.deltaTime, 0);
            x = Mathf.Lerp(x, NewXPos, Time.deltaTime * SpeedDodge);
            characControl.Move(moveVector);
            Jump();
        }
    }
    
    public void Jump()
    {
        if(characControl.isGrounded)
        {
            if(MoveUp)
            {
                y = JumpPower;
                InJump = true;
            }
        }
        else
        {
            y -= JumpPower * 2 * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(life);
        life = life - 1;
    }
}
