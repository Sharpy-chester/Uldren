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
        mainCamera = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {
        NPCName = transform.Find("CharacterName").gameObject;
        NPCNameTMP = NPCName.GetComponent<TextMeshPro>();
        NPCNameTMP.text = name;
    }

    // Update is called once per frame
    void Update()
    {
        NPCNameTMP.transform.LookAt(mainCamera.transform);
        NPCNameTMP.transform.localEulerAngles = new Vector3(0, NPCNameTMP.transform.localEulerAngles.y, NPCNameTMP.transform.localEulerAngles.z);
        NPCNameTMP.transform.localEulerAngles += new Vector3(0, 180, 0);
    }
}
