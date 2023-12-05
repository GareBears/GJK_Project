using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{
    public bool canSpawn;
    public GameObject[] obstacles;
    private float spawnPos;

    // Start is called before the first frame update
    void Start()
    {
        canSpawn = true;
    }

    // Update is called once per frame
    void Update()
    {
     
        if (canSpawn == true)
        {
            StartCoroutine(SpawnStuff());
        }
    }

    public IEnumerator SpawnStuff()
    {
        canSpawn = false;
        int obstacleIndex = Random.Range(0, obstacles.Length);
        spawnPos = Random.Range(0, 3);
        SpawnOb1(obstacleIndex);
        yield return new WaitForSeconds(2f);
        canSpawn = true;
    }

    public void SpawnOb1(int obToSpawn)
    {
        if (spawnPos == 0)
        {
            Instantiate(obstacles[obToSpawn], new Vector3(-2.5f, 0, 100), obstacles[obToSpawn].transform.rotation);
        }
        else if (spawnPos == 1)
        {
            Instantiate(obstacles[obToSpawn], new Vector3(0, 0, 100), obstacles[obToSpawn].transform.rotation);
        }
        else if (spawnPos == 2)
        {
            Instantiate(obstacles[obToSpawn], new Vector3(2.5f, 0, 100), obstacles[obToSpawn].transform.rotation);
        }
        
    }

    
}
