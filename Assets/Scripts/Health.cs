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


    void Start()
    {
        health = maxHealth;
        respawnManager = FindObjectOfType<RespawnManager>();
        Drogthor drogthor = FindObjectOfType<Drogthor>();
        if (drogthor.gameObject == gameObject)
        {
            drogthor.endingCutscene.SetActive(true);
        }
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
