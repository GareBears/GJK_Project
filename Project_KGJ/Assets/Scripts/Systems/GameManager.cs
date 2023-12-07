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

    public GameObject Obstacle;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerMove = player.GetComponent<PlayerMovement>();
        repeatGround = GameObject.Find("Ground").GetComponent<RepeatGround>();
        obstacles = Obstacle.GetComponent<Obstacles>();
        score = 0;
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

            if (score > 20)
            {
                SpeedUp();
            }

        }
    }

    public void SpeedUp()
    {
        if (score > 10)
        {
            repeatGround.SpeedUp(50);
            obstacles.SpeedUp(50);
        }
    }
}
