using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Interact))]
public class Dialogue : MonoBehaviour
{
    Interact interact;

    ThirdPersonController player;


    [SerializeField] TextMeshProUGUI displayText;

    [SerializeField] string[] dialogueLines;
    [SerializeField] string[] choice1Lines;
    [SerializeField] string[] choice2Lines;

    void Start()
    {
        //When the player is within the trigger and presses E, StartDialogue is called
        interact = GetComponent<Interact>();
        interact.onInteract += StartDiglogue;

        //Get the player GameObject
        player = FindObjectOfType<ThirdPersonController>();
    }

    void Update()
    {
        
    }


    void StartDiglogue()
    {
        displayText.transform.parent.gameObject.SetActive(true);
        player.enabled = false;
        StartCoroutine(ShowDialogue());
    }

    IEnumerator ShowDialogue()
    {
        // Display each line of dialogue
        for (int i = 0; i < dialogueLines.Length; i++)
        {
            // Show the current line of dialogue
            displayText.text = dialogueLines[i];

            yield return new WaitForSeconds(1);

            // Wait for the player to press the space key before showing the next line
            yield return new WaitUntil(() => Keyboard.current.eKey.isPressed);
        }

        if (choice1Lines.Length < 1)
        {
            StopDialogue();
            yield break;
        }

        // Show the branching choices
        displayText.text = "Choice 1: " + choice1Lines[0] + "\nChoice 2: " + choice2Lines[0];

        yield return new WaitForSeconds(1);

        // Wait for the player to make a choice
        yield return new WaitUntil(() => Keyboard.current.digit1Key.wasPressedThisFrame || Keyboard.current.digit2Key.isPressed);

        // Check which choice the player made
        if (Keyboard.current.digit1Key.isPressed)
        {
            StartCoroutine(ShowChoice1Lines());
        }
        else if (Keyboard.current.digit2Key.isPressed)
        {
            StartCoroutine(ShowChoice2Lines());
        }
    }

    IEnumerator ShowChoice1Lines()
    {
        // Display each line of dialogue for this choice
        for (int i = 1; i < choice1Lines.Length; i++)
        {
            // Show the current line of dialogue
            displayText.text = choice1Lines[i];

            yield return new WaitForSeconds(1);

            // Wait for the player to press the space key before showing the next line
            yield return new WaitUntil(() => Keyboard.current.eKey.isPressed);
        }
        StopDialogue();
    }

    IEnumerator ShowChoice2Lines()
    {
        // Display each line of dialogue for this choice
        for (int i = 1; i < choice2Lines.Length; i++)
        {
            // Show the current line of dialogue
            displayText.text = choice2Lines[i];

            yield return new WaitForSeconds(1);

            // Wait for the player to press the space key before showing the next line
            yield return new WaitUntil(() => Keyboard.current.eKey.isPressed);
        }
        StopDialogue();
    }

    void StopDialogue()
    {
        StartCoroutine(interact.ResetInteracted());
        player.enabled = true;
        displayText.transform.parent.gameObject.SetActive(false);
    }
}