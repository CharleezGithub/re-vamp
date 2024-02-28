using System.Collections;
using UnityEngine;

public class SlashingAttack : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    public float projectileSpeed;
    public float projectileLifetime;
    public float cooldownTime;

    private void Update()
    {
        StartCoroutine(SlashAttack());
    }

    private IEnumerator SlashAttack()
    {
        yield return new WaitForSeconds(cooldownTime);
        FireProjectile();
    }

    void FireProjectile()
    {
        Debug.Log("firing projectile");

        // Instantiate the projectile
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        // Calculate the direction based on player input
        Vector2 direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

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
            projectile.transform.Translate(direction * step);
            yield return null;
        }
    }
}
