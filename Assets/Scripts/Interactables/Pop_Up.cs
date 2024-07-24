using TMPro;
using UnityEngine;

public class Pop_Up : MonoBehaviour
{
    [Header("Interaction Prompt Object")]
    [SerializeField] private TextMeshProUGUI interactionPrompt;
    [Header("Interaction Prompt's Text: ")]
    [SerializeField] private string promptText;

    [Header("Interaction Prompt's Position X offset")]
    [SerializeField] private float xOffset;
    [Header("Interaction Prompt's Position Y offset")]
    [SerializeField] private float yOffset;

    [SerializeField] private GameObject dialogueScript;
    private Vector2 originalPosition;

    private bool isPlayerClose = false;
    private void Start()
    {
        if(interactionPrompt != null)
        {
            interactionPrompt.gameObject.SetActive(false);
            originalPosition = new Vector2(interactionPrompt.transform.position.x, interactionPrompt.transform.position.y);
        }
        CheckNull();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag ("Player"))
        {
            OpenAndRepositionPrompt();  
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        CloseAndReturnPrompt();
    }
    private void OpenAndRepositionPrompt()
    {
        if (interactionPrompt != null)
        {
            dialogueScript.SetActive(true);
            interactionPrompt.text = promptText.ToString();
            interactionPrompt.transform.position = new Vector2(transform.position.x + xOffset, transform.position.y + yOffset);
            interactionPrompt.gameObject.SetActive(true);
            isPlayerClose = true;
        }
    }
    private void CloseAndReturnPrompt()
    {
        if(interactionPrompt != null)
        {
            dialogueScript.SetActive(false);
            interactionPrompt.gameObject.SetActive(false);
            interactionPrompt.transform.position = originalPosition;
            isPlayerClose = false;
        }
    }
    public bool IsPlayerClose()
    {
        return isPlayerClose;
    }
    private void CheckNull()
    {
        if(interactionPrompt == null)
        {
            Debug.LogError("Interaction prompt object is not assigned or invalid");
        }
        if(float.IsNaN(xOffset))
        {
            Debug.LogError("X offset is not assigned or invalid");
        }
        if(float.IsNaN(yOffset))
        {
            Debug.Log("Y offset is not assigned or invalid");
        }
    }
}
