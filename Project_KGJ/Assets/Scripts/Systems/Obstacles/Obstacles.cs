using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public float moveDeduct = 20f;
    private float playerPosZ;
    public float despawnRange;
    private GameObject player;
    public float speedUp = 0;

    // Start is called before the first frame update
    void Start()
    {
        //moveDeduct = 20;
    }
    public void Awake()
    {
        //moveDeduct = speedUp;
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

    public void SpeedUp(float speed)
    {
        moveDeduct = moveDeduct + speed;
    }
}
