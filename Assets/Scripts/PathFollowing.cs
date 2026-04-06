using UnityEngine;
using UnityEngine.AI;

public class PathFollowing : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent agent;
    public GameManager manager;

    
    void Update() { 
        agent.destination = player.position; 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player Hit!");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            manager.LoadEndScreen();
        }
    }
}
