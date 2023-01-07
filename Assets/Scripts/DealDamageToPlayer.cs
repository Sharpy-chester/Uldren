using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamageToPlayer : MonoBehaviour
{
    [SerializeField] int damage = 2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ThirdPersonController>())
        {
            Health health = other.GetComponent<Health>();
            if (health != null)
            {
                health.DealDamage(damage);
            }
        }
    }
}
