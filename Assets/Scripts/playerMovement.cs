using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;
    public Rigidbody rb;

    void Start()
    {
        rb.freezeRotation = true;
    }

    void Update()
    {
        float x = 0, z = 0;

        if (Input.GetKey(KeyCode.D))
            x = 1;
        if (Input.GetKey(KeyCode.A)) 
            x = -1;
        if (Input.GetKey(KeyCode.W)) 
            z = 1;
        if (Input.GetKey(KeyCode.S))
            z = -1;

        Vector3 move = (transform.forward * z + transform.right * x) * speed;
        move.y = rb.velocity.y;
        rb.velocity = move;

        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.velocity.y) < 0.01f)
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}


