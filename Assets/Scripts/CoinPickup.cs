using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Coin Picked Up!");
            PlayerInventory inventory = other.GetComponent<PlayerInventory>();
            inventory.CoinAdd();
            Destroy(gameObject);
        }
    }


}
