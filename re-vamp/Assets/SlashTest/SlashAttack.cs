using UnityEngine;

public class SlashAttack : MonoBehaviour
{
    public LayerMask EnemyLayer;        // The layer where enemies are located
    public int attackDamage = 10;       // Damage for each attack
    public float attackInterval = 1.0f; // Time between each attack in seconds
    public float attackRange = 1.0f;    // The range of the attack
    public float attackAngle = 45.0f;   // The angle of the slash attack

    private Vector2 lastPosition;
    private Vector2 movementDirection;
    private Vector2 defaultAttackDirection = Vector2.right; // Default attack direction when stationary

    void Start()
    {
        lastPosition = transform.position;
        InvokeRepeating(nameof(AutoAttack), 0f, attackInterval);
    }

    void Update()
    {
        // Update movement direction
        movementDirection = (Vector2)transform.position - lastPosition;
        if (movementDirection != Vector2.zero)
        {
            movementDirection.Normalize();
        }
        lastPosition = transform.position;
    }

    void AutoAttack()
    {
        Vector2 attackDirection = movementDirection != Vector2.zero ? movementDirection : defaultAttackDirection;

        // Find enemies within a sector (slash area)
        Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(transform.position, attackRange, EnemyLayer);

        foreach (Collider2D enemy in enemiesInRange)
        {
            Vector2 directionToEnemy = enemy.transform.position - transform.position;
            float angle = Vector2.Angle(attackDirection, directionToEnemy);

            if (angle <= attackAngle / 2) // Enemy is within the slash angle
            {
                enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
            }
        }
    }
}
