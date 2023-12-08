using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool gameIsRunning = false;

    GameObject player;
    PlayerMovement playerMove;
    RepeatGround repeatGround;
    Obstacles obstacles;
    ObstacleSpawn spawner;

    float currentTime;
    public int score;
    public float multiplier = 5;

    public TMP_Text text;
    public GameObject title;
    public GameObject end;
    public TMP_Text finalScore;
    public GameObject startButton;
    public GameObject endButton;

    public GameObject obstacle;
    GameObject prefabObject; 

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerMove = player.GetComponent<PlayerMovement>();
        repeatGround = GameObject.Find("Ground").GetComponent<RepeatGround>();
        obstacles = obstacle.GetComponent<Obstacles>();
        spawner = GameObject.Find("SpawnManager").GetComponent <ObstacleSpawn>();
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
            title.SetActive(false);
        }
        
        if (playerMove.life == 0)
        {
            gameIsRunning = false;
            end.SetActive(true);
            finalScore.SetText("Score:" + score);
            endButton.SetActive(true);
        }

        if (gameIsRunning)
        {
            currentTime = currentTime + Time.deltaTime;
            score = Mathf.RoundToInt(currentTime * multiplier);
            text.text = score.ToString();
            TimeSpan time = TimeSpan.FromSeconds(currentTime);

            if (score == 150)
            {
                SpeedUp(.25f);
            }
            if (score == 300)
            {
                SpeedUp(.25f);
            }
            if (score == 450)
            {
                SpeedUp(.25f);
                spawner.turbospawn = true;
            }
            if (score == 600)
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

    public void RestartGame(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }

    public void Startgame()
    {
        gameIsRunning = true;
        title.SetActive(false);
        startButton.SetActive(false);
    }
}
