using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Health : MonoBehaviour
{
    [SerializeField] float maxHealth = 10;
    float health = 10;


    void Start()
    {
        health = maxHealth;
    }

    void CheckHealth()
    {
        if (health <= 0)
        {
            //kill
            print(gameObject.name + " died");
            if (GetComponent<EnemyAI>())
            {
                Destroy(GetComponent<EnemyAI>());
                Destroy(GetComponent<NavMeshAgent>());
                GetComponent<Animator>().SetTrigger("Dead");
                Destroy(GetComponent<BoxCollider>());
                Destroy(this);
            }
        }
        else
        {
            if (GetComponent<EnemyAI>())
            {
                GetComponent<Animator>().SetTrigger("Hit");
            }
        }
    }

    public void DealDamage(float damage)
    {
        health -= damage;
        
        CheckHealth();
    }

    public float GetHealth()
    {
        return health;
    }

    public void IncreaseHealth(float HPIncrease)
    {
        health += HPIncrease;
    }
}
