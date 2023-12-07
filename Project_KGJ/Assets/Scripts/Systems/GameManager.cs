using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    public bool gameIsRunning = false;

    GameObject player;
    PlayerMovement playerMove;
    RepeatGround repeatGround;
    Obstacles obstacles;

    float currentTime;
    public int score;
    public float multiplier = 5;

    public TMP_Text text;
    public TMP_Text scoretext;

    public GameObject obstacle;
    GameObject prefabObject; 

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerMove = player.GetComponent<PlayerMovement>();
        repeatGround = GameObject.Find("Ground").GetComponent<RepeatGround>();
        obstacles = obstacle.GetComponent<Obstacles>();
        score = 0;
        if (obstacles.moveDeduct > 20)
        {
            obstacles.moveDeduct = 20;
        }
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

        if (gameIsRunning)
        {
            currentTime = currentTime + Time.deltaTime;
            score = Mathf.RoundToInt(currentTime * multiplier);
            text.text = score.ToString();
            TimeSpan time = TimeSpan.FromSeconds(currentTime);

            if (score == 20)
            {
                SpeedUp(.25f);
            }
            if (score == 30)
            {
                SpeedUp(.25f);
            }
            if (score == 40)
            {
                SpeedUp(.25f);
            }

        }
    }

    public void SpeedUp(float speed)
    {
        repeatGround.SpeedUp(speed);
        obstacles.SpeedUp(speed);
    }
}
