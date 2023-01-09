using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Health : MonoBehaviour
{
    [SerializeField] float maxHealth = 10;
    float health = 10;
    RespawnManager respawnManager;
    bool isDrogthor = false;
    Drogthor drogthor;


    void Start()
    {
        health = maxHealth;
        respawnManager = FindObjectOfType<RespawnManager>();
        drogthor = FindObjectOfType<Drogthor>();
        if (drogthor.gameObject == gameObject)
        {
            isDrogthor = true;
        }
    }

    void CheckHealth()
    {
        if (health <= 0)
        {
            //kill
            
            if(isDrogthor)
            {
                drogthor.endingCutscene.SetActive(true);
            }
            if (GetComponent<EnemyAI>())
            {
                Destroy(GetComponent<EnemyAI>());
                Destroy(GetComponent<NavMeshAgent>());
                GetComponent<Animator>().SetTrigger("Dead");
                Destroy(GetComponent<BoxCollider>());
                Destroy(this);
            }
            if (GetComponent<ThirdPersonController>())
            {
                
                respawnManager.Respawn();
            }
        }
        else
        {
            if (GetComponent<EnemyAI>())
            {
                GetComponent<Animator>().SetTrigger("Hit");
            }
            UpdateHealthUI healthUI = GetComponent<UpdateHealthUI>();
            if (healthUI != null)
            {
                healthUI.UpdateHealthSlider(health / maxHealth);
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
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        CheckHealth();
    }
}
