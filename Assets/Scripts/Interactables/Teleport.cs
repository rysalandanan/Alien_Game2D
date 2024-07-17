using UnityEngine;

public class Teleport : MonoBehaviour
{
    private Pop_Up pop_up;
    [Header("Player reference: ")]
    [SerializeField] private GameObject player;
    [Header("Teleporter Exit's reference: ")]
    [SerializeField] private Transform teleporterExit;
    [Header("Player's X off set after teleport: ")]
    [SerializeField] private float xOffset;
    [Header("Main Game's Camera: ")]
    [SerializeField] private Camera mainCamera;
    [Header("Main Game's Camera new position: ")]
    [SerializeField] private Transform newCamPosition;

    private void Start()
    {
        pop_up = GetComponent<Pop_Up>();
        CheckNull();
    }
    private void Update()
    {
       PlayerInteract();
    }
    private void PlayerInteract()
    {
        if (pop_up != null)
        {
            if (pop_up.IsPlayerClose() && Input.GetKeyDown(KeyCode.E))
            {
                TeleportPlayer();
            }
        }
    }
    private void TeleportPlayer()
    {
        var exit = teleporterExit.transform.position;
        if (teleporterExit != null && player != null && newCamPosition != null)
        {
            player.transform.position = new Vector2(exit.x + xOffset, exit.y);
            mainCamera.transform.position = newCamPosition.transform.position;
        }
    }
    private void CheckNull()
    {
        if (player == null)
        {
            Debug.LogError("Player is not assigned or invalid");
        }
        if (teleporterExit == null)
        {
            Debug.LogError("Teleporter Exit is not assigned or invalid");
        }
        if (pop_up == null)
        {
            Debug.LogError("Pop Up is not assigned or invalid");
        }
        if(newCamPosition == null)
        {
            Debug.Log("New Camera Position is not assigned or invalid");
        }
    }
}
