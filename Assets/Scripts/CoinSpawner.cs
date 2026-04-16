using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab; // Assign your prefab in the Inspector
    public float spawnRangeX = 10f;
    public float spawnRangeZ = 10f;
    public float spawnHeight = 1f;

    void Start()
    {
        SpawnCoin();
    }

    public void SpawnCoin()
    {
        // Generate a random position within a range
        Vector3 randomPos = new Vector3(
            Random.Range(-spawnRangeX, spawnRangeX),
            spawnHeight,
            Random.Range(-spawnRangeZ, spawnRangeZ)
        );

        // Spawn the coin
        Instantiate(coinPrefab, randomPos, Quaternion.identity);
    }
}
