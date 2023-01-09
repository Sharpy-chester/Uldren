using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FireballSpell : MonoBehaviour
{
    
    [SerializeField] GameObject fireballPrefab;
    [SerializeField] Transform firePos;
    [SerializeField] float fireCooldown = 1.0f;
    [SerializeField] float fireVelocity = 10.0f;
    [SerializeField] float maxLength = 10000.0f;
    float currentCooldown = 0;
    int playerLayerMask;
    int raycastLayerMask;
    Camera camera;
    Animator animator;

    void Start()
    {
        camera = Camera.main;
        animator = GetComponent<Animator>();
        playerLayerMask = 1 << LayerMask.NameToLayer("Character");
        raycastLayerMask = ~playerLayerMask;
    }

    void Update()
    {
        currentCooldown += Time.deltaTime;
        if (currentCooldown > fireCooldown)
        {
            if(Mouse.current.leftButton.isPressed)
            {
                currentCooldown = 0;

                animator.Play("FireAttack");

                if (Physics.Raycast(camera.transform.position, camera.transform.forward, out RaycastHit hit, Mathf.Infinity, raycastLayerMask))
                {
                    Vector3 direction = Vector3.Normalize(hit.point - firePos.position);
                    GameObject fireball = Instantiate(fireballPrefab, firePos.position, Quaternion.identity);
                    Rigidbody rb = fireball.GetComponent<Rigidbody>();
                    rb.AddForce(direction * fireVelocity);
                }
                else
                {
                    Vector3 direction = Vector3.Normalize(camera.transform.forward * maxLength);
                    GameObject fireball = Instantiate(fireballPrefab, firePos.position, Quaternion.identity);
                    Rigidbody rb = fireball.GetComponent<Rigidbody>();
                    rb.AddForce(direction * fireVelocity);
                }
            }
        }
        
    }
}
