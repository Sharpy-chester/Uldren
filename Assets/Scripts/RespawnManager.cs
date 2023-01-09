using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    [SerializeField] Vector3 respawnPoint;
    [SerializeField] GameObject player;

    public void SetRespawnPoint(Vector3 position)
    {
        respawnPoint = position;
    }

    public void Respawn()
    {
        player.transform.Find("PlayerArmature").GetComponent<CharacterController>().enabled = false;
        player.transform.position = respawnPoint;
        player.transform.Find("PlayerArmature").position = respawnPoint;
        player.transform.Find("PlayerArmature").GetComponent<Health>().IncreaseHealth(1000);
        player.transform.Find("PlayerArmature").GetComponent<CharacterController>().enabled = true;
    }
}
