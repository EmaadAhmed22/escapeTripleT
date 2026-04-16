using UnityEngine;
using UnityEngine.UI; 

public class playerMovement : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float sprintSpeed = 10f;
    public float jumpForce = 5f;
    public Rigidbody rb;

    public Image staminaFill; 
    public float maxStamina = 100f;
    public float staminaDepletionRate = 40f;
    public float staminaRegenRate = 15f;
    public float regenDelay = 2f;

    private float currentStamina;
    private float currentSpeed;
    private float staminaRegenTimer;

    private bool disableM = false;

    void Start()
    {
        rb.freezeRotation = true;
        currentStamina = maxStamina;
        currentSpeed = walkSpeed;
    }

    void Update()
    {
        if (!disableM)
        {
            HandleMovement();
            HandleStamina();
        }   
    }

    void HandleMovement()
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

        bool isMoving = x != 0 || z != 0;

        if (Input.GetKey(KeyCode.LeftShift) && isMoving && currentStamina > 0)
        {
            currentSpeed = sprintSpeed;
            currentStamina -= staminaDepletionRate * Time.deltaTime;
            staminaRegenTimer = 0f;
        }
        else
        {
            currentSpeed = walkSpeed;
            if (currentStamina < maxStamina)
            {
                staminaRegenTimer += Time.deltaTime;
                if (staminaRegenTimer >= regenDelay)
                {
                    currentStamina += staminaRegenRate * Time.deltaTime;
                }
            }
        }

        currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);

        Vector3 move = (transform.forward * z + transform.right * x) * currentSpeed;
        move.y = rb.velocity.y;
        rb.velocity = move;

        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.velocity.y) < 0.01f)
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    void HandleStamina()
    {
        if (staminaFill != null)
        {
            staminaFill.fillAmount = currentStamina / maxStamina;
        }
    }


    public void disable() {
        disableM = true;
    }
}
