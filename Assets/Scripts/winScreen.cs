using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class winScreen : MonoBehaviour
{
   
    // Start is called before the first frame update
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerInventory inventory = collision.gameObject.GetComponent<PlayerInventory>();

            if (inventory.keys == 3)
            {
                SceneManager.LoadScene("winScreen");
            }
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
