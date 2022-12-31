using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CutsceneDialogue", menuName = "ScriptableObjects/CutsceneDialogue", order = 1)]
public class CutsceneDialogue : ScriptableObject
{
    [TextArea] public string[] dialogue;
    public float[] timeUntilNextDialogue;
    public AudioClip[] voiceOvers;
}
