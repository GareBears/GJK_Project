using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool gameIsRunning = false;

    GameObject player;
    PlayerMovement playerMove;
    RepeatGround repeatGround;
    Obstacles obstacles;

    public float score;

    public TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerMove = player.GetComponent<PlayerMovement>();
        repeatGround = GameObject.Find("Ground").GetComponent<RepeatGround>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            gameIsRunning = true;
            
        }
        
        if (playerMove.life == 0)
        {
            gameIsRunning = false;
        }

        //score += Time.deltaTime;

        text.SetText(score.ToString());
        

        if (gameIsRunning)
        {
            score += 1;
        }
    }

    public void LateUpdate()
    {
        obstacles = GameObject.Find("ObstacleTEST").GetComponent<Obstacles>();
    }
}
