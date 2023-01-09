using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAI : MonoBehaviour
{
    public GameObject player;
    public NavMeshAgent navMeshAgent;
    Animator animator;
    [SerializeField] float attackRange = 2f;
    [SerializeField] float aggroRange = 20f;
    Rigidbody rb;
    Vector3 lookPos;
    int enemyLayerMask;
    int raycastLayerMask;


    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = GetComponent<FireballSpell>().gameObject;
        animator.SetBool("Aggro", true);
        lookPos = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
        enemyLayerMask = 1 << LayerMask.NameToLayer("Enemy");
        raycastLayerMask = ~enemyLayerMask;
    }

    void Update()
    {
        if (player == null)
        {
            return;
        }
        lookPos = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
        Ray ray = new(lookPos, player.transform.position - lookPos);
        Debug.DrawLine(lookPos, player.transform.position, Color.green);
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, raycastLayerMask))
        {
            if (hit.transform.CompareTag("Player") && Vector3.Distance(lookPos, hit.transform.position) < aggroRange)
            {
                
                animator.SetBool("SeePlayer", true);
                float distance = Vector3.Distance(lookPos, player.transform.position);
                if (distance < attackRange)
                {
                    navMeshAgent.ResetPath();
                    
                    Attack();
                }
                else if (distance < aggroRange)
                {
                    navMeshAgent.SetDestination(player.transform.position);
                }
            }
            else
            {
                animator.SetBool("SeePlayer", false);
            }
        }
        animator.SetFloat("Speed", navMeshAgent.velocity.magnitude);
        print(navMeshAgent.velocity.magnitude);
    }

    void Attack()
    {
        //Play anims and damage player
        animator.SetTrigger("Attack");
    }
}
