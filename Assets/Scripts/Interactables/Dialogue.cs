using TMPro;
using UnityEngine;
using System.Collections;

public class Dialogue : MonoBehaviour
{
    private Pop_Up pop_up;
    [SerializeField] private GameObject dialogueBox;
    private int currentLineIndex = 0;
    private bool isTyping = false;

    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private string[] dialogueLines;
    [SerializeField] private float typingSpeed = 0.05f;

    void Start()
    {
        pop_up = GetComponentInParent<Pop_Up>();
        CheckNull();
    }

    void Update()
    {
        if (pop_up != null)
        {
            if (pop_up.IsPlayerClose() && Input.GetKeyDown(KeyCode.E) && !dialogueBox.activeInHierarchy)
            {
                StartDialogue();
            }
            else if (dialogueBox.activeInHierarchy && Input.GetKeyDown(KeyCode.F) && !isTyping)
            {
                NextLine();
            }
        }
    }

    private void StartDialogue()
    {
        currentLineIndex = 0;
        StartCoroutine(TypeLine());
        dialogueBox.SetActive(true);
    }

    private IEnumerator TypeLine()
    {
        isTyping = true;
        dialogueText.text = "";
        foreach (char letter in dialogueLines[currentLineIndex].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSecondsRealtime(typingSpeed);
        }
        isTyping = false;
    }

    private void NextLine()
    {
        if (currentLineIndex < dialogueLines.Length - 1)
        {
            currentLineIndex++;
            StartCoroutine(TypeLine());
        }
        else
        {
            EndDialogue();
        }
    }

    private void EndDialogue()
    {
        dialogueBox.SetActive(false);
    }

    private void CheckNull()
    {
        if (pop_up == null)
        {
            Debug.LogError("Pop up is not assigned or invalid.");
        }
        if (dialogueBox == null)
        {
            Debug.LogError("Dialogue Box is not assigned or invalid.");
        }
        if (dialogueText == null)
        {
            Debug.LogError("Dialogue Text is not assigned or invalid.");
        }
        if (dialogueLines == null || dialogueLines.Length == 0)
        {
            Debug.LogError("Dialogue Lines are not assigned or empty.");
        }
    }
}