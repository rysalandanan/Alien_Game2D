using System.Collections;
using UnityEngine;

public class LightFlickering : MonoBehaviour
{
    [SerializeField] private GameObject lightObject;
    private void Start()
    {
        StartCoroutine(LightOn());
    }

    private IEnumerator LightOn()
    {
        yield return new WaitForSeconds(0.3f);
        StartCoroutine(Flickering());
    }
    private IEnumerator Flickering()
    {
        lightObject.SetActive(false);
        float randomIndex = Random.Range(0.1f,0.3f );
        yield return new WaitForSeconds(randomIndex);
        lightObject.SetActive(true);
        StartCoroutine(LightOn());
    }
}
