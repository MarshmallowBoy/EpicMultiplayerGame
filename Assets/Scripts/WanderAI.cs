using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WanderAI : MonoBehaviour
{
    private int moveSpeed = 10;
    [Space]
    private float timer = 0;
    public float timeToMove = 10;
    public float timeToStop = 5;
    public float timeToJump = Random.Range(1, 7);
    [Space]
    private bool isMoving = false;

    NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        timer = Time.time;
        if(agent.velocity.x > 0 && isMoving == false || agent.velocity.z > 0 && isMoving == false)
        {
            isMoving = true;
        }

        if(timer >= timeToJump)
        {
            Jump(Random.Range(1, 20));
        }

        if(isMoving == false && timer >= timeToMove)
        {
            timer = 0;
            Wander();
        }

        else if(isMoving == true && timer >= timeToStop)
        {
            timer = 0;
            isMoving = false;
        }
    }

    private void Wander()
    {
        float wanderZ = Random.Range(1, 10);
        float wanderX = Random.Range(1, 10);

    }

    private void Jump(float power)
    {
        //jumps
        
    }
}