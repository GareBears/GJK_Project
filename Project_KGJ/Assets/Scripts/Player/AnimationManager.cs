using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    Animator animator;
    GameManager gameManger;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        gameManger = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManger.gameIsRunning == true)
        {
            animator.Play("Base Layer.Take 001", 3, 3);
        }
        if (gameManger.gameIsRunning == false)
        {
            animator.Play("Base Layer.Take 001", 0, 0);
        }
    }
}
