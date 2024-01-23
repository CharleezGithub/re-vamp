using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public float attackRange = 1.0f;  // The range of the attack
    public LayerMask EnemyLayer;      // The layer where enemies are located
    public int attackDamage = 10;     // Damage for each attack
    public float attackInterval = 1.0f; // Time between each attack in seconds
    public GameObject enemy;

    void Start()
    {
        // Start the auto-attack repeating every 'attackInterval' seconds
        InvokeRepeating("AutoAttack", 0f, attackInterval);
    }

    void AutoAttack()
    {
        Collider2D hitEnemy = Physics2D.OverlapCircle(transform.position, attackRange, EnemyLayer);
        if (hitEnemy != null) // Check if an enemy is within range
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
            Debug.Log("Enemy hit!");
        }
    }

    void OnDrawGizmosSelected()
    {
        // Display the attack range in the editor
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
