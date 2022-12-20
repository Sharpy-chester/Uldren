using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAI : MonoBehaviour
{
    public GameObject player;
    public NavMeshAgent navMeshAgent;
    public float attackRange = 2f;

    void Update()
    {
        navMeshAgent.SetDestination(player.transform.position);
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance < attackRange)
        {
            Attack();
        }
    }

    void Attack()
    {
        //Play anims and damage player
    }
}
