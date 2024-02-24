using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float dashMultiplier = 3f; // Multiplier for dash speed
    public float dashDuration = 0.2f; // Duration of the dash in seconds
    public float dashCooldown = 2f; // Cooldown duration for the dash in seconds
    private float initialXScale;

    private Vector2 movement;
    private Rigidbody2D rb;
    private float dashEndTime;
    private float nextDashTime;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Store the initial x scale
        initialXScale = transform.localScale.x;
    }

    void Update()
    {
        // Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        FlipPlayer();// Flips the player towards the x axis it is going

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
    void FlipPlayer()
    {
        // Apply the scale to flip the enemy if pressing left or right key
        if (movement.x != 0)
            transform.localScale = new Vector3(movement.x, transform.localScale.y, transform.localScale.z);
    }
}
