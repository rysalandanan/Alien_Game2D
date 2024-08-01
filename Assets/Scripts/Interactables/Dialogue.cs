using TMPro;
using UnityEngine;
using System.Collections;

public class Dialogue : MonoBehaviour
{
    private Interact interact;
    private int currentLineIndex = 0;
    private bool isTyping = false;

    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private string[] dialogueLines;
    [SerializeField] private float typingSpeed = 0.05f;

    void Start()
    {
        interact = GetComponentInParent<Interact>();
        CheckNull();
    }

    void Update()
    {
        if (interact != null && dialogueText != null) 
        {
            if(interact.IsPlayerClose())
            {
                if(Input.GetKeyDown(KeyCode.E) && !dialogueText.gameObject.activeInHierarchy)
                {
                    StartDialogue();
                }
                else if (dialogueText.gameObject.activeInHierarchy && Input.GetKeyDown(KeyCode.RightArrow) && !isTyping)
                {
                    NextLine();
                }
            }
        }
    }

    private void StartDialogue()
    {
        currentLineIndex = 0;
        StartCoroutine(TypeLine());
        dialogueText.gameObject.SetActive(true);
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
        dialogueText.gameObject.SetActive(false);
    }

    private void CheckNull()
    {
        if (interact == null)
        {
            Debug.LogError("Pop up is not assigned or invalid.");
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