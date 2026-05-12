using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{

    public AudioSource audioSource;
    


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Key Picked Up!");
            PlayerInventory inventory = other.GetComponent<PlayerInventory>();
            inventory.AddKey();
            Destroy(gameObject);
            audioSource.Play();
        }
    }

    
}
