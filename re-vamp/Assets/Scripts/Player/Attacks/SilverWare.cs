using System.Collections;
using UnityEngine;

public class SilverWareLauncher : MonoBehaviour
{
    public GameObject[] silverWare;
    public int amountPerBurst = 5; // Amount of silverware to launch per burst
    public float burstCooldown = 2f; // Cooldown time between bursts in seconds
    public float projectileSpeed = 10f; // Speed at which the silverware will be launched
    public float projectileLifetime = 5f;

    private Vector2 direction;

    [SerializeField]private GameObject player;

    private void Update()
    {
        StartCoroutine(Burst());
    }

    IEnumerator Burst()
    {
        yield return new WaitForSeconds(burstCooldown);
        for (int i = 0; i < amountPerBurst; i++)
        {
            FireProjectile(silverWare[i]);
            yield return new WaitForSeconds(0.1f);
        }
    }

    void FireProjectile(GameObject projectilePrefab)
    {   
        // Instantiate the projectile
        GameObject projectile = Instantiate(projectilePrefab, player.transform.position, Quaternion.identity);

        // Calculate the angle towards the direction
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Rotate the projectile to face the moving direction
        projectile.transform.rotation = Quaternion.Euler(0f, 0f, angle - 90); // Adjusted by -90 degrees if needed, depending on your sprite's default orientation

        // Move the projectile in the direction without rigidbody
        StartCoroutine(MoveProjectile(projectile, direction));

        // Destroy the projectile after its lifetime
        Destroy(projectile, projectileLifetime);
    }

    IEnumerator MoveProjectile(GameObject projectile, Vector2 direction)
    {
        while (projectile != null)
        {
            float step = projectileSpeed * Time.deltaTime;

            // Move the projectile forward in the direction it's facing
            projectile.transform.Translate(Vector3.up * step, Space.Self); // Use Vector3.right if sprite faces to the right by default

            yield return null;
        }
    }
}


/*
 
private bool isCooldown = false; // To control the cooldown period between bursts

    void Update()
    {
        if (!isCooldown)
        {
            StartCoroutine(LaunchBurst());
        }
    }

    private IEnumerator LaunchBurst()
    {
        isCooldown = true;

        for (int i = 0; i < amountPerBurst; i++)
        {
            LaunchSilverware();
            yield return new WaitForSeconds(0.1f); // Small delay between each launch in a burst
        }

        yield return new WaitForSeconds(burstCooldown);
        isCooldown = false;
    }

    void LaunchSilverware()
    {
        if (silverWare.Length == 0)
            return;

        // Randomly select a silverware prefab
        int index = Random.Range(0, silverWare.Length);
        GameObject selectedSilverware = silverWare[index];

        // Instantiate the silverware
        GameObject launchedObject = Instantiate(selectedSilverware, transform.position, Quaternion.identity);

        // Correct the orientation to face upwards if necessary
        launchedObject.transform.up = Vector2.up; // This assumes the prefab's default orientation is upwards

        // Apply velocity
        Rigidbody2D rb = launchedObject.AddComponent<Rigidbody2D>(); // Adding Rigidbody2D component
        rb.gravityScale = 0; // Making sure it doesn't fall down due to gravity
        rb.velocity = transform.up * launchSpeed; // Launching in the 'up' direction relative to the world
    }

 */