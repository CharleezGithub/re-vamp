using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float dashMultiplier = 3f; // Multiplier for dash speed
    public float dashDuration = 0.2f; // Duration of the dash in seconds
    public float dashCooldown = 2f; // Cooldown duration for the dash in seconds

    private Vector2 movement;
    private Rigidbody2D rb;
    private float dashEndTime;
    private float nextDashTime;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextDashTime)
        {
            Dash();
        }
    }
      
    void FixedUpdate()
    {
        float currentSpeed = moveSpeed;

        // If we are dashing, increase the move speed
        if (Time.time < dashEndTime)
        {
            currentSpeed *= dashMultiplier;
        }

        // Movement
        rb.velocity = (currentSpeed * Time.fixedDeltaTime * movement);
    }

    void Dash()
    {   
        // Start the dash
        dashEndTime = Time.time + dashDuration;
        nextDashTime = Time.time + dashCooldown;
    }
}
