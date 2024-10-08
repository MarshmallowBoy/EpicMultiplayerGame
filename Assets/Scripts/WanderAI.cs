using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WanderAI : MonoBehaviour
{
    private int moveSpeed = 10;
    [Space]
    [SerializeField] float chaseDistance = 10;
    [SerializeField] float tempHomeDistance = 1;
    private float timer = 0;
    public float timeToMove = 10;
    public float timeToStop = 7;
    public float timeToJump;
    [Space]
    [SerializeField] bool playerInSight = false;
    private bool isMoving = false;

    [SerializeField] GameObject player;
    public NavMeshAgent agent;
    public float range;

    public Transform centerPoint;

    Vector3 home;
    Vector3 tempHome;


    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        timeToJump = Random.Range(1, 7);
        home = transform.position;
        if (player == null)
        {
            player = GameObject.FindWithTag("Player").gameObject;
        }
    }

    private void Update()
    {
        //timer = Time.deltaTime;
        Vector3 moveDir = player.transform.position - transform.position;
        if (agent.remainingDistance <= agent.stoppingDistance && timer >= timeToMove)
        {
            Vector3 point;
            if(RandomPoint(centerPoint.position, range, out point))
            {
                Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f);
                agent.SetDestination(point);
            }
        }
        if (moveDir.magnitude < chaseDistance)
        {
            playerInSight = true;
        }
        else if (moveDir.magnitude > chaseDistance)
        {
            playerInSight = false;
        }
        if (playerInSight == true)
        {
            if (tempHome.x == 0)
            {
                tempHome = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            }
            agent.destination = player.transform.position;
        }
        else if (playerInSight == false)
        {
            agent.destination = tempHome;
            if (moveDir.magnitude <= tempHomeDistance)
            {
                Vector3 _point;
                if(RandomPoint(centerPoint.position, range, out _point))
                {
                    agent.SetDestination(_point);
                }
                tempHome.x = 0;
                tempHome.y = 0;
                tempHome.z = 0;
            }
        }
    }

    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        Vector3 randomPoint = center + Random.insideUnitSphere * range;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
        {
            result = hit.position;
            return true;
        }
        result = Vector3.zero;
        return false;
    }

    private void Jump(float power)
    {
        //jumps
        power = Random.Range(0, 10);
    }
}