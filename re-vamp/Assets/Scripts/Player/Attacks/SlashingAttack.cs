using System.Collections;
using UnityEngine;

public class SlashingAttack : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    public float projectileSpeed;
    public float projectileLifetime;
    public float cooldownTime;

    Vector2 direction;
    bool isAttacking = false;

    Transform playerTransform;

    private void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        playerTransform = Player.Instance.transform;
    }

    private void Update()
    {
        if (!isAttacking)
            StartCoroutine(SlashAttack());
    }

    private IEnumerator SlashAttack()
    {
        isAttacking = true;
        yield return new WaitForSeconds(cooldownTime);
        FireProjectile();
        isAttacking = false;
    }
    void FireProjectile()
    {
        // Calculate the direction based on player input
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        else
            direction = new Vector2(Random.Range(-1, 2), Random.Range(-1, 2));

        if (direction == Vector2.zero)
            direction = Vector2.one;

        // Instantiate the projectile
        GameObject projectile = Instantiate(projectilePrefab, playerTransform.position, Quaternion.identity);

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
            projectile.transform.Translate(Vector3.up * step, Space.Self); // Use Vector3.right if your sprite faces to the right by default

            yield return null;
        }
    }
}

