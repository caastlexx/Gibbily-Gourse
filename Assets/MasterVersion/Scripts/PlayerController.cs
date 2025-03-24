using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Maximum speed
    public static float acceleration = 10f; // How quickly the player accelerates
    public float deceleration = 10f; // How quickly the player slows down
    public static Rigidbody rb;
    private float targetVelocityX; // Desired velocity based on input
    private float currentVelocityX; //adjusted velocity
    public static bool waterBottle = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("No Rigidbody attached to the player!");
        }
        
    }

    void Update()
    {
        // Get horizontal input (A/D or Left/Right arrow keys)
        if (waterBottle == false) {
            float moveInput = Input.GetAxisRaw("Horizontal");
            targetVelocityX = moveInput * moveSpeed;
        } else if (waterBottle == true) {
            float moveInput = Input.GetAxisRaw("Horizontal") * -1;
            targetVelocityX = moveInput * moveSpeed;
        }
    }

    void FixedUpdate()
    {
        // horizontal velocity for sliding effect
        currentVelocityX = Mathf.Lerp(currentVelocityX, targetVelocityX, 
            (targetVelocityX == 0 ? deceleration : acceleration) * Time.fixedDeltaTime);

        // Apply the smoothed velocity
        rb.velocity = new Vector3(currentVelocityX, rb.velocity.y, rb.velocity.z);
    }
}