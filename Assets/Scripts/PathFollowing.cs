using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class PathFollowing : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent agent;
    public GameManager manager;


    public GameObject playerCamera; // FPS camera
    public GameObject scareCamera;  // Camera in monster's face
    public AudioSource scareSound;
    public playerMovement movement; // Script to disable movement
    public CameraFollow camera; // Script to disable movement

    public float shakeDuration = 0.5f;
    public float shakeIntensity = 0.2f;

    void Start()
    {
        agent.speed = GameManager.speed;
        agent.acceleration = GameManager.acceleration;

    }
    void Update() { 
        agent.destination = player.position; 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player Hit!");
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
        movement.disable();
        camera.disable();

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

        manager.LoadEndScreen();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
