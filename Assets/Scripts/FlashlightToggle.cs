using UnityEngine;

public class FlashlightToggle : MonoBehaviour
{
    private Light flashlight;

    void Start()
    {
        flashlight = GetComponent<Light>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            flashlight.enabled = !flashlight.enabled;
        }
    }
}
