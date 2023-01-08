using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    RespawnManager respawnManager;

    void Start()
    {
        respawnManager = FindObjectOfType<RespawnManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ThirdPersonController>())
        {
            respawnManager.SetRespawnPoint(transform.position);
        }    
    }
}
