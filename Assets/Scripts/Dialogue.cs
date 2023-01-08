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
    CharacterName characterName;

    [SerializeField] TextMeshProUGUI displayText;
    [SerializeField] TextMeshProUGUI displayName;

    [SerializeField] string dialogueName;

    [SerializeField] string[] dialogueLines;
    [SerializeField] int dialogueChoicesNeeded = 0;

    [SerializeField] string[] choice1Lines;
    [SerializeField] int Choice1LinesNeeded = 0;
    [SerializeField] string[] choice1aLines;
    [SerializeField] string[] choice1bLines;
    [SerializeField] string[] choice1cLines;

    [SerializeField] string[] choice2Lines;
    [SerializeField] int Choice2LinesNeeded = 0;
    [SerializeField] string[] choice2aLines;
    [SerializeField] string[] choice2bLines;
    [SerializeField] string[] choice2cLines;

    [SerializeField] string[] choice3Lines;
    [SerializeField] int Choice3LinesNeeded = 0;
    [SerializeField] string[] choice3aLines;
    [SerializeField] string[] choice3bLines;
    [SerializeField] string[] choice3cLines;


    void Start()
    {
        //When the player is within the trigger and presses E, StartDialogue is called
        interact = GetComponent<Interact>();
        interact.onInteract += StartDialogue;

        //Get the player GameObject
        player = FindObjectOfType<ThirdPersonController>();
        characterName = GetComponent<CharacterName>();
    }

    void Update()
    {

    }


    public void StartDialogue()
    {
        displayText.transform.parent.gameObject.SetActive(true);
        player.enabled = false;

        if (string.IsNullOrEmpty(dialogueName))
        {
            dialogueName = characterName.name;
        }
        displayName.text = dialogueName;

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
        if (dialogueChoicesNeeded == 1)
        {
            displayText.text = "Choice 1: " + choice1Lines[0];
        }
        else if (dialogueChoicesNeeded == 2)
        {
            displayText.text = "Choice 1: " + choice1Lines[0] + "\nChoice 2: " + choice2Lines[0];
        }
        else if (dialogueChoicesNeeded == 3)
        {
            displayText.text = "Choice 1: " + choice1Lines[0] + "\nChoice 2: " + choice2Lines[0] + "\nChoice 3: " + choice3Lines[0];
        }

        yield return new WaitForSeconds(1);

        // Wait for the player to make a choice
        yield return new WaitUntil(() => Keyboard.current.digit1Key.isPressed || Keyboard.current.digit2Key.isPressed || Keyboard.current.digit3Key.isPressed);

        // Check which choice the player made
        if (Keyboard.current.digit1Key.isPressed && dialogueChoicesNeeded >= 1)
        {
            StartCoroutine(ShowChoice1Lines());
        }
        else if (Keyboard.current.digit2Key.isPressed && dialogueChoicesNeeded >= 2)
        {
            StartCoroutine(ShowChoice2Lines());
        }
        else if (Keyboard.current.digit3Key.isPressed && dialogueChoicesNeeded >= 3)
        {
            StartCoroutine(ShowChoice3Lines());
        }
    }

    #region Choices 1
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

        if (choice1aLines.Length < 1)
        {
            StopDialogue();
            yield break;
        }

        // Show the branching choices
        if (Choice1LinesNeeded == 1)
        {
            displayText.text = "Choice 1: " + choice1aLines[0];
        }
        else if (Choice1LinesNeeded == 2)
        {
            displayText.text = "Choice 1: " + choice1aLines[0] + "\nChoice 2: " + choice1bLines[0];
        }
        else if (Choice1LinesNeeded == 3)
        {
            displayText.text = "Choice 1: " + choice1aLines[0] + "\nChoice 2: " + choice1bLines[0] + "\nChoice 3: " + choice1cLines[0];
        }

        yield return new WaitForSeconds(1);

        // Wait for the player to make a choice
        yield return new WaitUntil(() => Keyboard.current.digit1Key.isPressed || Keyboard.current.digit2Key.isPressed || Keyboard.current.digit3Key.isPressed);

        // Check which choice the player made
        if (Keyboard.current.digit1Key.isPressed && Choice1LinesNeeded >= 1)
        {
            StartCoroutine(ShowChoice1aLines());
        }
        else if (Keyboard.current.digit2Key.isPressed && Choice1LinesNeeded >= 2)
        {
            StartCoroutine(ShowChoice1bLines());
        }
        else if (Keyboard.current.digit3Key.isPressed && Choice1LinesNeeded >= 3)
        {
            StartCoroutine(ShowChoice1cLines());
        }
    }

    #region Secondary Choices 1
    IEnumerator ShowChoice1aLines()
    {
        // Display each line of dialogue for this choice
        for (int i = 1; i < choice1aLines.Length; i++)
        {
            // Show the current line of dialogue
            displayText.text = choice1aLines[i];

            yield return new WaitForSeconds(1);

            // Wait for the player to press the space key before showing the next line
            yield return new WaitUntil(() => Keyboard.current.eKey.isPressed);
        }
        StopDialogue();
    }

    IEnumerator ShowChoice1bLines()
    {
        // Display each line of dialogue for this choice
        for (int i = 1; i < choice1bLines.Length; i++)
        {
            // Show the current line of dialogue
            displayText.text = choice1bLines[i];

            yield return new WaitForSeconds(1);

            // Wait for the player to press the space key before showing the next line
            yield return new WaitUntil(() => Keyboard.current.eKey.isPressed);
        }
        StopDialogue();
    }

    IEnumerator ShowChoice1cLines()
    {
        // Display each line of dialogue for this choice
        for (int i = 1; i < choice1cLines.Length; i++)
        {
            // Show the current line of dialogue
            displayText.text = choice1cLines[i];

            yield return new WaitForSeconds(1);

            // Wait for the player to press the space key before showing the next line
            yield return new WaitUntil(() => Keyboard.current.eKey.isPressed);
        }
        StopDialogue();
    }
    #endregion
    #endregion

    #region Choices 2
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

        if (choice2aLines.Length < 1)
        {
            StopDialogue();
            yield break;
        }

        // Show the branching choices
        if (Choice2LinesNeeded == 1)
        {
            displayText.text = "Choice 1: " + choice2aLines[0];
        }
        else if (Choice2LinesNeeded == 2)
        {
            displayText.text = "Choice 1: " + choice2aLines[0] + "\nChoice 2: " + choice2bLines[0];
        }
        else if (Choice2LinesNeeded == 3)
        {
            displayText.text = "Choice 1: " + choice2aLines[0] + "\nChoice 2: " + choice2bLines[0] + "\nChoice 3: " + choice2cLines[0];
        }

        yield return new WaitForSeconds(1);

        // Wait for the player to make a choice
        yield return new WaitUntil(() => Keyboard.current.digit1Key.isPressed || Keyboard.current.digit2Key.isPressed || Keyboard.current.digit3Key.isPressed);

        // Check which choice the player made
        if (Keyboard.current.digit1Key.isPressed && Choice2LinesNeeded >= 1)
        {
            StartCoroutine(ShowChoice2aLines());
        }
        else if (Keyboard.current.digit2Key.isPressed && Choice2LinesNeeded >= 2)
        {
            StartCoroutine(ShowChoice2bLines());
        }
        else if (Keyboard.current.digit3Key.isPressed && Choice2LinesNeeded >= 3)
        {
            StartCoroutine(ShowChoice2cLines());
        }

    }

    #region Secondary Choices 2
    IEnumerator ShowChoice2aLines()
    {
        // Display each line of dialogue for this choice
        for (int i = 1; i < choice2aLines.Length; i++)
        {
            // Show the current line of dialogue
            displayText.text = choice2aLines[i];

            yield return new WaitForSeconds(1);

            // Wait for the player to press the space key before showing the next line
            yield return new WaitUntil(() => Keyboard.current.eKey.isPressed);
        }
        StopDialogue();
    }

    IEnumerator ShowChoice2bLines()
    {
        // Display each line of dialogue for this choice
        for (int i = 1; i < choice2bLines.Length; i++)
        {
            // Show the current line of dialogue
            displayText.text = choice2bLines[i];

            yield return new WaitForSeconds(1);

            // Wait for the player to press the space key before showing the next line
            yield return new WaitUntil(() => Keyboard.current.eKey.isPressed);
        }
        StopDialogue();
    }

    IEnumerator ShowChoice2cLines()
    {
        // Display each line of dialogue for this choice
        for (int i = 1; i < choice2cLines.Length; i++)
        {
            // Show the current line of dialogue
            displayText.text = choice2cLines[i];

            yield return new WaitForSeconds(1);

            // Wait for the player to press the space key before showing the next line
            yield return new WaitUntil(() => Keyboard.current.eKey.isPressed);
        }
        StopDialogue();
    }
    #endregion
    #endregion

    #region Choices 3
    IEnumerator ShowChoice3Lines()
    {
        // Display each line of dialogue for this choice
        for (int i = 1; i < choice3Lines.Length; i++)
        {
            // Show the current line of dialogue
            displayText.text = choice3Lines[i];

            yield return new WaitForSeconds(1);

            // Wait for the player to press the space key before showing the next line
            yield return new WaitUntil(() => Keyboard.current.eKey.isPressed);
        }

        if (choice3aLines.Length < 1)
        {
            StopDialogue();
            yield break;
        }

        // Show the branching choices
        if (Choice3LinesNeeded == 1)
        {
            displayText.text = "Choice 1: " + choice3aLines[0];
        }
        else if (Choice3LinesNeeded == 2)
        {
            displayText.text = "Choice 1: " + choice3aLines[0] + "\nChoice 2: " + choice3bLines[0];
        }
        else if (Choice3LinesNeeded == 3)
        {
            displayText.text = "Choice 1: " + choice3aLines[0] + "\nChoice 2: " + choice3bLines[0] + "\nChoice 3: " + choice3cLines[0];
        }

        yield return new WaitForSeconds(1);

        // Wait for the player to make a choice
        yield return new WaitUntil(() => Keyboard.current.digit1Key.isPressed || Keyboard.current.digit2Key.isPressed || Keyboard.current.digit3Key.isPressed);

        // Check which choice the player made
        if (Keyboard.current.digit1Key.isPressed && Choice3LinesNeeded >= 1)
        {
            StartCoroutine(ShowChoice3aLines());
        }
        else if (Keyboard.current.digit2Key.isPressed && Choice3LinesNeeded >= 2)
        {
            StartCoroutine(ShowChoice3bLines());
        }
        else if (Keyboard.current.digit3Key.isPressed && Choice3LinesNeeded >= 3)
        {
            StartCoroutine(ShowChoice3cLines());
        }
    }

    #region Secondary Choices 3
    IEnumerator ShowChoice3aLines()
    {
        // Display each line of dialogue for this choice
        for (int i = 1; i < choice3aLines.Length; i++)
        {
            // Show the current line of dialogue
            displayText.text = choice3aLines[i];

            yield return new WaitForSeconds(1);

            // Wait for the player to press the space key before showing the next line
            yield return new WaitUntil(() => Keyboard.current.eKey.isPressed);
        }
        StopDialogue();
    }

    IEnumerator ShowChoice3bLines()
    {
        // Display each line of dialogue for this choice
        for (int i = 1; i < choice3bLines.Length; i++)
        {
            // Show the current line of dialogue
            displayText.text = choice3bLines[i];

            yield return new WaitForSeconds(1);

            // Wait for the player to press the space key before showing the next line
            yield return new WaitUntil(() => Keyboard.current.eKey.isPressed);
        }
        StopDialogue();
    }

    IEnumerator ShowChoice3cLines()
    {
        // Display each line of dialogue for this choice
        for (int i = 1; i < choice3cLines.Length; i++)
        {
            // Show the current line of dialogue
            displayText.text = choice3cLines[i];

            yield return new WaitForSeconds(1);

            // Wait for the player to press the space key before showing the next line
            yield return new WaitUntil(() => Keyboard.current.eKey.isPressed);
        }
        StopDialogue();
    }
    #endregion
    #endregion

    void StopDialogue()
    {
        StartCoroutine(interact.ResetInteracted());
        player.enabled = true;
        displayText.transform.parent.gameObject.SetActive(false);
    }
}