using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float mouseSensitivity = 2f;
    private float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        transform.position = target.position + Vector3.up * 0.4f;

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        target.Rotate(Vector3.up * mouseX);
        transform.rotation = target.rotation * Quaternion.Euler(xRotation, 0, 0);
    }
}
