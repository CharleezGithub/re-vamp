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

        StartCoroutine(GetTopParent());
    }

    private void Update()
    {
        if (!isAttacking)
            StartCoroutine(SlashAttack());
    }

    private IEnumerator GetTopParent()
    {
        Transform currentParent = transform.parent;

        // Keep going up the hierarchy until there's no parent left
        while (currentParent.parent != null)
        {
            currentParent = currentParent.parent;
        }

        playerTransform = currentParent;
        yield return null;
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
        // Instantiate the projectile
        GameObject projectile = Instantiate(projectilePrefab, playerTransform.position, Quaternion.identity);

        // Calculate the direction based on player input
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        else
            direction = Vector2.zero;

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
            if (direction == Vector2.zero)
                direction = new Vector2(Random.Range(-1, 2), Random.Range(-1, 2));
            projectile.transform.Translate(direction * step);
            yield return null;
        }
    }
}
