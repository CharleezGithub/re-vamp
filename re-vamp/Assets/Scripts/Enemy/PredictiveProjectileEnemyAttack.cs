using UnityEngine;

public class PredictiveProjectileEnemyAttack : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject target;
    public float fireInterval = 2f;
    public float projectileSpeed = 5f;
    public float projectileLifetime = 3f;
    Rigidbody2D projectileRigidbody;
    Rigidbody2D targetRigidbody;
    void Start()
    {
        InvokeRepeating("FireProjectile", 0, fireInterval);
    }
    void FireProjectile()
    {
        targetRigidbody = target.GetComponent<Rigidbody2D>();
        Vector2 directionToTarget = (target.transform.position - transform.position);
        Vector2 relativeVelocity = new Vector2(projectileSpeed - targetRigidbody.velocity.x, projectileSpeed - targetRigidbody.velocity.y);
        float timeOfImpact = Vector2.Dot(directionToTarget, relativeVelocity) / relativeVelocity.sqrMagnitude;
        Vector2 predictedTargetPosition = (Vector2)target.transform.position + targetRigidbody.velocity * timeOfImpact;
        GameObject newProjectile = Instantiate(projectile, transform.position, Quaternion.identity);
        projectileRigidbody = newProjectile.GetComponent<Rigidbody2D>();
        Vector2 directionToPredictedTarget = (predictedTargetPosition - (Vector2)newProjectile.transform.position).normalized;
        projectileRigidbody.velocity = directionToPredictedTarget * projectileSpeed;
        Destroy(newProjectile, projectileLifetime);
    }
}
