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
    public float attackDamage = 10f; // Damage for each attack
    [Space(10)]

    [Header("Debug")]
    GameObject enemy;
    bool isAttacking;

    public GameObject damagePopupPrefab; // Assign your TMP prefab in the inspector.

    private void Start()
    {
        if (!isProjectile)
            StartCoroutine(AutoAttack());// Start the auto-attack repeating every 'attackInterval' seconds
    }
    IEnumerator AutoAttack()
    {
        while (true)
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, attackRange, EnemyLayer);
            foreach (Collider2D hitEnemy in hitEnemies)
            {
                if (hitEnemy.TryGetComponent(out EnemyHealth enemyHealth))
                {
                    enemyHealth.TakeDamage((int)attackDamage);
                    DamagePopup.CreatePopUp(hitEnemy.transform.position, ((int)attackDamage).ToString());
                }
            }
            yield return new WaitForSeconds(attackInterval);
        }
    }
    // Method to call when damage is dealt.
    void OnDrawGizmosSelected()
    {
        // Display the attack range in the editor
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isProjectile && collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage((int)attackDamage);
        }
    }
}
