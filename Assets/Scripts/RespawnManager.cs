using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    Vector3 respawnPoint;
    [SerializeField] Transform player;

    void Start()
    {
        respawnPoint = player.position;
    }

    public void SetRespawnPoint(Vector3 position)
    {
        respawnPoint = position;
    }

    public void Respawn()
    {
        player.position = respawnPoint;
        player.GetComponent<Health>().IncreaseHealth(1000);
    }
}
