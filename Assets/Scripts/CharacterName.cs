using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterName : MonoBehaviour
{
    GameObject NPCName;
    TextMeshPro NPCNameTMP;
    Camera mainCamera;

    [SerializeField] new string name;

    private void Awake()
    {
        // Get the main camera
        mainCamera = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Change text of the NPC name tag above them
        NPCName = transform.Find("CharacterName").gameObject;
        NPCNameTMP = NPCName.GetComponent<TextMeshPro>();
        NPCNameTMP.text = name;
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate nametag towards camera
        NPCNameTMP.transform.LookAt(mainCamera.transform);
        NPCNameTMP.transform.localEulerAngles = new Vector3(0, NPCNameTMP.transform.localEulerAngles.y, NPCNameTMP.transform.localEulerAngles.z);
        NPCNameTMP.transform.localEulerAngles += new Vector3(0, 180, 0);
    }
}
