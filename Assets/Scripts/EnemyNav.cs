using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNav : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField] GameObject player;
    [SerializeField] float chaseDistance = 10;
    Vector3 home;

    void Awake()
    {
        home = transform.position;
        agent = GetComponent<NavMeshAgent>();
        if(player == null)
        {
            player = GameObject.FindWithTag("Player").gameObject;
        }
    }

    void Update()
    {
        Vector3 moveDir = player.transform.position - transform.position;
        if(moveDir.magnitude < chaseDistance)
        {
            agent.destination = player.transform.position;
        }
        else
        {
            agent.destination = home;
        }
    }
}
