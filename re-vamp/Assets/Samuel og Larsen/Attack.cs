using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public float attackRange = 1.0f;  // The range of the attack
    public LayerMask enemyLayer;      // The layer where enemies are located
    public int attackDamage = 10;     // Damage for each attack

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Check if left mouse button is pressed
        {
            AttackIfEnemyIsClose();
        }
    }

    void AttackIfEnemyIsClose()
    {
        Collider2D hitEnemy = Physics2D.OverlapCircle(transform.position, attackRange, enemyLayer);
        if (hitEnemy != null) // Check if an enemy is within range
        {
            // Implement the attack logic here, e.g., reducing enemy health
            // Example:
            hitEnemy.GetComponent<health>().TakeDamage(attackDamage);
            Debug.Log("Enemy hit!");
        }
    }

    void OnDrawGizmosSelected()
    {
        // Display the attack range in the editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}