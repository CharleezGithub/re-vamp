using UnityEngine;

public class ExplotionDamage : MonoBehaviour
{
    [SerializeField] private ParticleSystem particleSystem; // Assign your particle system in the inspector
    public LayerMask EnemyLayer; // The layer where enemies are located
    private int attackDamage = 10;

    void Start()
    {
        // Spawn particles at the start
        SpawnParticleEffect();

        // Apply damage to enemies within range
        ApplyDamage();
    }

    void OnDrawGizmosSelected()
    {
        // Display the attack range in the editor
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, transform.localScale.y / 2);
    }

    private void SpawnParticleEffect()
    {
        if (particleSystem != null)
        {
            ParticleSystem ps = Instantiate(particleSystem, transform.position, Quaternion.identity);
            ps.transform.localScale = Vector3.one / transform.localScale.y / 10; // Adjust the scale after instantiation
            ps.Play();
            Destroy(ps.gameObject, 3); // Corrected to destroy after 3 seconds
        }
        else
        {
            Debug.LogError("ParticleSystem is not assigned in the inspector.");
        }
    }

    private void ApplyDamage()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, transform.localScale.y / 2, EnemyLayer);
        foreach (Collider2D hitEnemy in hitEnemies)
        {
            Debug.Log(hitEnemy);
            EnemyHealth enemyHealth = hitEnemy.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(attackDamage);
            }
            else
            {
                Debug.LogError("EnemyHealth component not found on the hit object.");
            }
        }
    }
}
