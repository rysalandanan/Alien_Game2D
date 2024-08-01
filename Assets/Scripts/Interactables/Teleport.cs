using UnityEngine;

public class Teleport : MonoBehaviour
{
    [Header("Player reference: ")]
    [SerializeField] private GameObject player;
    [Header("Teleporter Exit's reference: ")]
    [SerializeField] private Transform teleporterExit;

    [Header("Main Game's Camera: ")]
    [SerializeField] private Camera mainCamera;
    [Header("Main Game's Camera new position: ")]
    [SerializeField] private Transform cameraTargetPosition;

    private void Start()
    {
        CheckNull();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            TeleportPlayer();
        }
    }
    private void TeleportPlayer()
    {
        if (teleporterExit != null && player != null && cameraTargetPosition != null)
        {
            var exitPosition = teleporterExit.transform.position;
            player.transform.position = new Vector2(exitPosition.x, exitPosition.y);

            var targetCameraPosition = cameraTargetPosition.transform.position;
            mainCamera.transform.position = new Vector3(targetCameraPosition.x, targetCameraPosition.y, mainCamera.transform.position.z);
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
        if(cameraTargetPosition == null)
        {
            Debug.Log("New Camera Position is not assigned or invalid");
        }  
    }
}
