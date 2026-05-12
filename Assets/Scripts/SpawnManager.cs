using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject ventPrefab;
    public GameObject keyPrefab;
    public GameObject playerPrefab;
    public GameObject monsterPrefab;

    public Transform[] ventSpawnPoints;
    public Transform[] keySpawnPoints;
    public Transform[] playerSpawnPoints;
    public Transform[] monsterSpawnPoints;

    public GameManager gameManager;   // Reference to your game manager
    public GameObject playerCamera;
    public GameObject scareCamera;
    public AudioSource scareAudio;
    public AudioSource footstepsAudio;
    public playerMovement movementScript;
    public CameraFollow cameraFollowScript;
    public Transform playerTransform;


    void Start()
    {
        SpawnEntities();
    }

    void SpawnEntities()
    {
        if (ventSpawnPoints.Length > 0)
        {
            Transform spawnPoint = ventSpawnPoints[Random.Range(0, ventSpawnPoints.Length)];
            Instantiate(ventPrefab, spawnPoint.position, spawnPoint.rotation);
        }

        //if (keySpawnPoints.Length > 0)
        //{
        //    for (int i = 0; i < 3; i++)
        //    {
        //        if (keySpawnPoints.Length > i)
        //        {
        //            Transform spawnPoint = keySpawnPoints[Random.Range(0, keySpawnPoints.Length)];
        //            Instantiate(keyPrefab, spawnPoint.position, spawnPoint.rotation);
        //        }
        //    }
        //}


        if (playerSpawnPoints.Length > 0)
        {
            Transform spawnPoint = playerSpawnPoints[Random.Range(0, playerSpawnPoints.Length)];
            playerPrefab.transform.position = spawnPoint.position;

        }
        GameObject monster = null;
        if (monsterSpawnPoints.Length > 0)
        {
            Transform spawnPoint = monsterSpawnPoints[Random.Range(0, monsterSpawnPoints.Length)];
            monster = Instantiate(monsterPrefab, spawnPoint.position, spawnPoint.rotation);
        }
        GameObject camObj = null;
        if (monster != null)
        {
            Camera childCam = monster.GetComponentInChildren<Camera>(true); // 'true' means include inactive
            if (childCam != null)
            {
                camObj = childCam.gameObject;
            }

        }

        MonsterFootsteps footsteps = monster.GetComponent<MonsterFootsteps>();
        PathFollowing pathFollow = monster.GetComponent<PathFollowing>();


        if (footsteps != null)
        {
            footsteps.player = playerTransform;
            footsteps.audioSource = footstepsAudio; // Assuming audio is on same obj
        }

        if (pathFollow != null)
        {
            pathFollow.player = playerTransform;
            pathFollow.manager = gameManager;
            pathFollow.playerCamera = playerCamera;
            pathFollow.scareCamera = camObj;
            pathFollow.scareSound = scareAudio;
            pathFollow.movement = movementScript;
            pathFollow.camera = cameraFollowScript;
            pathFollow.shakeDuration = 1.0f;
            pathFollow.shakeIntensity = 0.3f;

        }


    }
}
