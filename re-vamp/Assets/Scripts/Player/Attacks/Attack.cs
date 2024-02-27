using UnityEngine;

public class Attack : MonoBehaviour
{
    [Space(10)]
    public bool isProjectile;
    [Space(10)]
    [Header("If not a projectile")]
    public float attackRange = 1.0f;  // The range of the attack
    public float attackInterval = 1.0f; // Time between each attack in seconds
    [Space(10)]
    [Header("Necesary variables")]
    public LayerMask EnemyLayer; // The layer where enemies are located
    public int attackDamage = 10; // Damage for each attack
    [Space(10)]
    [Header("Debug")]
    public GameObject enemy;

    void Start()
    {
        if (!isProjectile)
            InvokeRepeating(nameof(AutoAttack), 0f, attackInterval);// Start the auto-attack repeating every 'attackInterval' seconds
    }
    void AutoAttack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, attackRange, EnemyLayer);
        foreach (Collider2D hitEnemy in hitEnemies)
        {
            hitEnemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
        }
    }
    void OnDrawGizmosSelected()
    {
        // Display the attack range in the editor
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (CompareTag("Enemy"))
        {
            GetComponent<EnemyHealth>().TakeDamage(attackDamage);
        }
    }
}
