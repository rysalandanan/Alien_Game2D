using TMPro;
using UnityEngine;

public class Interact : MonoBehaviour
{
    [Header("Interaction Prompt Object")]
    [SerializeField] private TextMeshProUGUI interactionPrompt;
    [Header("Interaction Prompt's Text: ")]
    [SerializeField] private string promptText;

    [Header("Interaction Prompt's Position X offset")]
    [SerializeField] private float xOffset;
    [Header("Interaction Prompt's Position Y offset")]
    [SerializeField] private float yOffset;

    [Header("Dialogue Line Script:")]
    [SerializeField] private GameObject lines;

    private Vector2 originalPosition;

    private bool isPlayerClose = false;
    private void Start()
    {
        if(interactionPrompt != null)
        {
            originalPosition = new Vector2(interactionPrompt.transform.position.x, interactionPrompt.transform.position.y);
        }
        CheckNull();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag ("Player"))
        {
            // Show the interaction prompt and reposition it near the object where the player is near //
            OpenAndRepositionPrompt();  
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        // Close the interaction prompt and return to its original position (outside of the camera's view) //
        CloseAndReturnPrompt();
    }
    private void OpenAndRepositionPrompt()
    {
        if (interactionPrompt != null)
        {
            interactionPrompt.text = promptText.ToString();
            var TranPos = transform.position;
            interactionPrompt.transform.position = new Vector2(TranPos.x + xOffset, TranPos.y + yOffset);
            interactionPrompt.gameObject.SetActive(true);
            isPlayerClose = true;
        }
        if (lines != null)
        {
            lines.SetActive(true);
        }    

            
    }
    private void CloseAndReturnPrompt()
    {
        if(interactionPrompt != null)
        {
            interactionPrompt.gameObject.SetActive(false);
            interactionPrompt.transform.position = originalPosition;
            isPlayerClose = false;
        }
        if (lines != null)
        {
            lines.SetActive(false);
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
