using System.Collections;
using System.Collections.Generic;
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
        
    [Header("If a projectile")]
    public float projectileAttackInterval = 0.1f; // Time between each attack in seconds
    [Space(10)]

    [Header("Necesary variables")]
    public LayerMask EnemyLayer; // The layer where enemies are located
    public int attackDamage = 10; // Damage for each attack
    [Space(10)]

    [Header("Debug")]
    GameObject enemy;
    bool isAttacking;

    public GameObject damagePopupPrefab; // Assign your TMP prefab in the inspector.

    bool projectileFired;
    private void Update()
    {
        if (!isAttacking && !isProjectile)
            StartCoroutine(AutoAttack());// Start the auto-attack repeating every 'attackInterval' seconds
    }
    IEnumerator AutoAttack()
    {
        isAttacking = true;

        yield return new WaitForSeconds(attackInterval);
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, attackRange, EnemyLayer);
        foreach (Collider2D hitEnemy in hitEnemies)
        {
            hitEnemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
            DamagePopup.CreatePopUp(hitEnemy.transform.position, attackDamage.ToString());
        }
        isAttacking = false;
    }

    // Method to call when damage is dealt.
    void OnDrawGizmosSelected()
    {
        // Display the attack range in the editor
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        projectileFired = false;
        if (isProjectile && collision.gameObject.CompareTag("Enemy"))
        {
            enemy = collision.gameObject;
            if(!projectileFired)
            StartCoroutine(ProjectileAttack());
        }
    }
    IEnumerator ProjectileAttack()
    {
        projectileFired = true;
        yield return new WaitForSeconds(projectileAttackInterval);
        enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
    }
}
