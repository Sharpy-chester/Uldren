using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CutsceneDialogueSys : MonoBehaviour
{
    [SerializeField] CutsceneDialogue dialogue;
    [SerializeField] GameObject subtitleUI;
    [SerializeField] TextMeshProUGUI dialogueTxt;
    [SerializeField] AudioSource audioSource;
    [SerializeField] bool startOnStart = false;
    [SerializeField] bool isEndingCutscene = false;
    [SerializeField] GameObject endingCutscene;

    private void Start()
    {
        if (startOnStart)
        {
            StartCoroutine(StartCutscene());
        }
    }

    void OnEnable()
    {
        if (!startOnStart)
        {
            StartCoroutine(StartCutscene());
        }
    }

    public IEnumerator StartCutscene()
    {
        dialogueTxt.transform.parent.gameObject.SetActive(true);
        if (isEndingCutscene)
        {
            endingCutscene.SetActive(true);
            Destroy(GameObject.Find("Prince Drogthor of the underworld"));
            Camera.main.transform.parent = null;
            Destroy(FindObjectOfType<ThirdPersonController>().gameObject);
            Destroy(GameObject.Find("Egron the changeling"));
        }
        for (int i = 0; i < dialogue.dialogue.Length; i++)
        {
            dialogueTxt.text = dialogue.dialogue[i];
            if(audioSource != null)
            {
                audioSource.clip = dialogue.voiceOvers[i];
                audioSource.Play();
            }
            yield return new WaitForSeconds(dialogue.timeUntilNextDialogue[i]);
        }
        dialogueTxt.transform.parent.gameObject.SetActive(false);
        Destroy(gameObject);
    }

    public void ChangeCutsceneDialogue(CutsceneDialogue cutsceneDialogue)
    {
        dialogue = cutsceneDialogue;
    }

}
