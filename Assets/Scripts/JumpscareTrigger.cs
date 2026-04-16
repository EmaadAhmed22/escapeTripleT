using UnityEngine;
using System.Collections;

public class JumpscareTrigger : MonoBehaviour
{
    public GameObject playerCamera; 
    public GameObject scareCamera;  
    public AudioSource scareSound;
    public GameObject playerController; 
    public float shakeDuration = 0.5f;
    public float shakeIntensity = 0.2f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(TriggerScare());
        }
    }

    IEnumerator TriggerScare()
    {
        // 1. Switch Camera
        playerCamera.SetActive(false);
        scareCamera.SetActive(true);
        scareSound.Play();

        // 2. Disable Movement
        if (playerController != null) playerController.SetActive(false);

        // 3. Camera Shake
        Vector3 originalPos = scareCamera.transform.localPosition;
        float elapsed = 0f;
        while (elapsed < shakeDuration)
        {
            scareCamera.transform.localPosition = originalPos + Random.insideUnitSphere * shakeIntensity;
            elapsed += Time.deltaTime;
            yield return null;
        }
        scareCamera.transform.localPosition = originalPos;

        // 4. Optional: End game or revert after delay
    }
}
