using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtractXP : MonoBehaviour
{
    // Adjust the speed to control how fast orbs move towards the player
    public float orbMovementSpeed = 5f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object entering the trigger is an XP orb
        if (other.CompareTag("XPOrb"))
        {
            // Get a reference to the orb's transform
            Transform orbTransform = other.transform;

            // Convert the player's position to a Vector3 for consistency
            Vector3 playerPosition = transform.position;

            // Calculate the direction from the orb to the player
            Vector3 directionToPlayer = playerPosition - orbTransform.position;

            // Normalize the direction vector to get a unit vector
            directionToPlayer.Normalize();

            // Calculate the new position for the orb using Vector3
            Vector3 newPosition = orbTransform.position + directionToPlayer * orbMovementSpeed * Time.deltaTime;

            // Update the orb's position
            orbTransform.position = newPosition;

            // Optionally, convert newPosition to Vector2 if necessary
            Vector2 newPosition2D = new Vector2(newPosition.x, newPosition.y);
        }
    }
}
