using UnityEngine;

public class PauseWhenActive : MonoBehaviour
{
    void Start()
    {
        this.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        Time.timeScale = 0f;
    }
    private void OnDisable()
    {
        Time.timeScale = 1f;
    }
}
