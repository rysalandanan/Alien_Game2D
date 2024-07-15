using UnityEngine;

public class Pop_Up : MonoBehaviour
{
    [Header("Pop Up Object")]
    [SerializeField] private GameObject popUpObject;
    [Header("Pop Up Object's Position X offset")]
    [SerializeField] private float xOffset;
    [Header("Pop Up Object's Position Y offset")]
    [SerializeField] private float yOffset;
    private Vector2 originalPosition;

    private bool isPlayerClose = false;
    private void Start()
    {
        popUpObject.SetActive(false);
        originalPosition = new Vector2(popUpObject.transform.position.x, popUpObject.transform.position.y);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag ("Player"))
        {
            popUpObject.transform.position = new Vector2(transform.position.x + xOffset, transform.position.y + yOffset);
            popUpObject.SetActive (true);
            isPlayerClose = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        popUpObject.SetActive(false);
        popUpObject.transform.position = originalPosition;
        isPlayerClose = false;
    }
    public bool IsPlayerClose()
    {
        return isPlayerClose;
    }
}
