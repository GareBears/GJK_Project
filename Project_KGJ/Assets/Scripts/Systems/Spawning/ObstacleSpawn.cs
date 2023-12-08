using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{
    private bool canSpawn;
    public GameObject[] obstacles;
    private float spawnPos;
    private float spawnAllowance;

    public bool turbospawn = false;

    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        canSpawn = true;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.gameIsRunning == true)
        {
            if (turbospawn == false)
            {
                spawnAllowance = Random.Range(0, 3);
            }
            else if (turbospawn == true)
            {
                spawnAllowance = Random.Range(0, 2);
            }
            
            if (canSpawn == true)
            {
                StartCoroutine(SpawnStuff());
            }
        }
    }

    public IEnumerator SpawnStuff()
    {
        canSpawn = false;
        int obstacleIndex = Random.Range(0, obstacles.Length);
        spawnPos = Random.Range(0, 3);
        SpawnOb1(obstacleIndex);
        yield return new WaitForSeconds(spawnAllowance);
        canSpawn = true;
    }

    public void SpawnOb1(int obToSpawn)
    {
        if (spawnPos == 0)
        {
            Instantiate(obstacles[obToSpawn], new Vector3(-2.5f, -.5f, 125), obstacles[obToSpawn].transform.rotation);
        }
        else if (spawnPos == 1)
        {
            Instantiate(obstacles[obToSpawn], new Vector3(0, -.5f, 125), obstacles[obToSpawn].transform.rotation);
        }
        else if (spawnPos == 2)
        {
            Instantiate(obstacles[obToSpawn], new Vector3(2.5f, -.5f, 125), obstacles[obToSpawn].transform.rotation);
        }
        
    }

    
}
