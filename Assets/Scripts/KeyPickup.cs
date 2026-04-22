using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{

    public string keyName = "key";
    public AudioSource keyPickup;
    


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Key Picked Up!");
            PlayerInventory inventory = other.GetComponent<PlayerInventory>();
            inventory.AddKey(keyName);
            Destroy(gameObject);
            keyPickup.Play();
        }
    }

    
}
