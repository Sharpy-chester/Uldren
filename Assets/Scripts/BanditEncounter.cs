using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditEncounter : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject teleportLocation;
    [SerializeField] Dialogue dialogue;
    [SerializeField] BoxCollider collider;
    [SerializeField] GameObject[] bandits;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject i in bandits)
        {
            // Disable the GameObject
            i.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider that entered the trigger is the player
        if (other.tag == "Player")
        {
            // Disable collider
            collider.enabled = false;

            // Teleport the player to the teleportPosition
            other.transform.position = teleportLocation.transform.position;

            //Start Dialogue
            dialogue.StartDialogue();

            foreach (GameObject i in bandits)
            {
                // Disable the GameObject
                i.SetActive(true);
            }
        }
    }
}
