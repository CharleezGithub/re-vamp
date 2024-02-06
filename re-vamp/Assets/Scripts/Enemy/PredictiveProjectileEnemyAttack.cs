using UnityEngine;

public class PredictiveProjectileEnemyAttack : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject target;
    public float fireInterval = 2f;
    public float projectileSpeed = 5f;
    public float projectileLifetime = 3f;
    void Start()
    {
        ReapeatLoop();
        targetRB = target.GetComponent<Rigidbody2D>();
    }
    void ReapeatLoop()
    {
        InvokeRepeating(nameof(FireProjectile), 0, fireInterval);
    }
    Rigidbody2D targetRB;

    void FireProjectile()
    {
        Vector2 playerVel = targetRB.velocity;
        Vector2 directionToTarget;
        if (playerVel.magnitude < 0.01f)
            directionToTarget = (target.transform.position - transform.position).normalized;
        else
        directionToTarget = calculateFireDirection(target.transform.position, transform.position, target.GetComponent<Rigidbody2D>().velocity, projectileSpeed);
        
        GameObject newProjectile = Instantiate(projectile, transform.position, Quaternion.identity);
        var rb = newProjectile.GetComponent<Rigidbody2D>();
        if (directionToTarget == -Vector2.one)
            directionToTarget = (target.transform.position - transform.position).normalized;
        rb.velocity = directionToTarget.normalized * projectileSpeed;
        Destroy(newProjectile, projectileLifetime);
    }

    private static Vector2 calculateFireDirection(Vector2 targetPosition, Vector2 turretPosition, Vector2 targetVelocity, float bulletSpeed)
    {
        Vector2 turretToTarget = targetPosition - turretPosition;

        float a = targetVelocity.x * targetVelocity.x + targetVelocity.y * targetVelocity.y - bulletSpeed * bulletSpeed;
        float b = 2.0f * Vector3.Dot(targetVelocity, turretToTarget);

        float p = -b / (2 * a);
        float q = (float)Mathf.Sqrt((b * b) - 4 * a * (turretToTarget.x * turretToTarget.y + turretToTarget.y * turretToTarget.y)) / (2 * a);

        float t = Mathf.Max(p - q, p + q);

        if (t > 0)
        {
            Vector2 tp = targetPosition;
            Vector2 tv = targetVelocity;
            Vector2 collisionPoint = tp + tv;

            return collisionPoint - turretPosition;
        }
        else
            return -Vector2.one; // This means the collision will never happen (or happened before the shot was fired, which is nonsensical).
    }
}
