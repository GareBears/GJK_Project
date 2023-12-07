using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public float moveDeduct;
    private float playerPosZ;
    public float despawnRange;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        moveDeduct = 20;
    }
    public void Awake()
    {
        player = GameObject.Find("Player");
        playerPosZ = player.transform.position.z;
        despawnRange = playerPosZ - 10;
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - moveDeduct * Time.deltaTime);
        
        if (transform.position.z < despawnRange)
        {
            Destroy(gameObject);
        }
    }

    public void SpeedUp(int speed)
    {
        moveDeduct = speed;
    }
}
