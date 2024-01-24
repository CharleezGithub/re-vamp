using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    float maxSpeed = 2.0f; // Maximum speed of the object.
    float acceleration = 4.0f; // Acceleration factor for smoother movement.
    public GameObject player;
    private void Start()
    {
    }

    private void FixedUpdate()
    {
        Vector2 playerPos = player.transform.position;

        // Calculate the direction (velocity) towards the cursor.
        Vector2 direction = (playerPos - (Vector2)transform.position).normalized;

        // Calculate the desired velocity based on maximum speed.
        Vector2 desiredVelocity = direction * maxSpeed;

        // Apply acceleration to smoothly reach the desired velocity.
        Vector2 velocity = Vector2.Lerp(GetComponent<Rigidbody2D>().velocity, desiredVelocity, Time.deltaTime * acceleration);

        // Update the object's velocity.
        GetComponent<Rigidbody2D>().velocity = velocity;

        // Ensure the object faces the cursor direction (optional).
        if (direction != Vector2.zero)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
