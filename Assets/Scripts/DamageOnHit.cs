using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnHit : MonoBehaviour
{
    [SerializeField] float damage = 3.0f;

    private void OnCollisionEnter(Collision collision)
    {
        Health health = collision.gameObject.GetComponent<Health>();
        if (health != null)
        {
            collision.gameObject.GetComponent<Health>().DealDamage(damage);
        }
    }
}
