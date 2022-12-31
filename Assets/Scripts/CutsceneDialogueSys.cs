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

    public IEnumerator StartCutscene()
    {
        for(int i = 0; i < dialogue.dialogue.Length; i++)
        {
            dialogueTxt.text = dialogue.dialogue[i];
            audioSource.clip = dialogue.voiceOvers[i];
            audioSource.Play();
            yield return new WaitForSeconds(dialogue.timeUntilNextDialogue[i]);
        }
    }

    public void ChangeCutsceneDialogue(CutsceneDialogue cutsceneDialogue)
    {
        dialogue = cutsceneDialogue;
    }

}
