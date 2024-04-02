using System.Collections;
using UnityEngine;

public class SpellTome : MonoBehaviour
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
        if (!isAttacking && projectilePrefab != null)
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

        // Move the projectile in the direction without rigidbody
        StartCoroutine(MoveProjectile(projectile));

        // Destroy the projectile after its lifetime
        Destroy(projectile, projectileLifetime);
    }
    IEnumerator MoveProjectile(GameObject projectile)
    {
        while (projectile != null)
        {
            float step = projectileSpeed * Time.deltaTime;
            direction = new Vector2(Random.Range(-1, 2), Random.Range(-1, 2));
            projectile.transform.Translate(direction * step);
            yield return null;
        }
    }
}
