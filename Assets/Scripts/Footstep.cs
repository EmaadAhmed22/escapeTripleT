using UnityEngine;

public class MonsterFootsteps : MonoBehaviour
{

    public Transform player;
    public AudioSource audioSource;

    public float minDistance = 5f;
    public float maxDistance = 15f;
    public float minVolume = 0f;
    public float maxVolume = 1f;

    void Start()
    {
       if (!audioSource.isPlaying)
            audioSource.Play();
    }

    void Update()
    {

        float distance = Vector3.Distance(transform.position, player.position);

        float volume = 1 - Mathf.Clamp01((distance - minDistance) / (maxDistance - minDistance));
        volume = Mathf.Lerp(minVolume, maxVolume, volume);

        audioSource.volume = volume;
    }
}
