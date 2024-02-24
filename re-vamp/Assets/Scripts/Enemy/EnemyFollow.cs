using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class EnemyFollow : MonoBehaviour
{
    float maxSpeed = 2.0f; // Maximum speed of the object.
    float acceleration = 4.0f; // Acceleration factor for smoother movement.
    private float initialXScale;
    public GameObject player;

    Vector2 direction;


    private void Start()
    {
        // find reference to the player through its tag
        player = GameObject.FindGameObjectWithTag("Player");

        // Store the initial x scale
        initialXScale = transform.localScale.x;
    }
    private void FixedUpdate()
    {
        Vector2 playerPos = player.transform.position;

        // Calculate the direction (velocity) towards the cursor.
        direction = (playerPos - (Vector2)transform.position).normalized;

        // Calculate the desired velocity based on maximum speed.
        Vector2 desiredVelocity = direction * maxSpeed;

        // Apply acceleration to smoothly reach the desired velocity.
        Vector2 velocity = Vector2.Lerp(GetComponent<Rigidbody2D>().velocity, desiredVelocity, Time.deltaTime * acceleration);

        // Update the object's velocity.
        GetComponent<Rigidbody2D>().velocity = velocity;

        // flip the enemy based on the players position
        bool isPlayerToLeft = direction.x < 0;

        // Set the x scale of the enemy based on the player's position
        float xScale = isPlayerToLeft ? -1 : 1;

        // If the initial x scale is -1, flip it to 1 and vice versa
        xScale *= (initialXScale == -1) ? -1 : 1;

        // Apply the scale to flip the enemy
        transform.localScale = new Vector3(xScale, transform.localScale.y, transform.localScale.z);
    }
    private void FaceThePlayerAtAllTime()
    {
        // Ensure the object faces the cursor direction (optional).
        if (direction != Vector2.zero)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}


