using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamageToPlayer : MonoBehaviour
{
    [SerializeField] int damage = 2;
    bool hit;
    BoxCollider box;

    private void Start()
    {
        box = GetComponent<BoxCollider>();
    }

    void Update()
    {
        if(box.enabled == false)
        {
            hit = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        print(other.transform.gameObject.name);
        if (other.GetComponent<ThirdPersonController>() && !hit)
        {
            Health health = other.GetComponent<Health>();
            if (health != null)
            {
                
                hit = true;
                health.DealDamage(damage);
            }
        }
    }
}
