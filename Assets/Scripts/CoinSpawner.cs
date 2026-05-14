using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab; // Assign your coin prefab in the inspector
    private GameObject currentCoin; // Keeps track of the currently active coin
    public Transform spawnPoint; // Optional: Assign a spawn location

    void Update()
    {
        // 1. Check if the current coin reference is null (meaning it was destroyed)
        if (currentCoin == null)
        {
            SpawnNewCoin();
        }
    }

    void SpawnNewCoin()
    {
        // 2. Instantiate the new coin and store it in the 'currentCoin' variable
        Vector3 position = spawnPoint != null ? spawnPoint.position : transform.position;
        currentCoin = Instantiate(coinPrefab, position, Quaternion.identity);
    }
}
