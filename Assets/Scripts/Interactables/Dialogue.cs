using UnityEngine;

public class Dialogue : MonoBehaviour
{
    private Pop_Up pop_up;
    [SerializeField] private GameObject dialogueBox;
    void Start()
    {
        pop_up = GetComponent<Pop_Up>();
        CheckNull();
    }
    void Update()
    {
        if (pop_up != null)
        {
            if(pop_up.IsPlayerClose() && Input.GetKeyDown(KeyCode.E))
            {
                dialogueBox.SetActive(true);
            }
        }
    }
    private void CheckNull()
    {
        if(pop_up == null)
        {
            Debug.LogError("Pop up is not assigned or invalid.");
        }
    }
}
