using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatGround : MonoBehaviour
{
    public float moveDeduct;
    private float startPosz;
    private Vector3 startPos;

    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        moveDeduct = 20;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.gameIsRunning)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - moveDeduct * Time.deltaTime);
            if (transform.position.z < startPos.z - 50)
            {
                transform.position = startPos;
            }
        }
    }

    public void SpeedUp(int speed)
    {
        moveDeduct = speed;
    }
}
