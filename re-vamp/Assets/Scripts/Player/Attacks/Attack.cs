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

    [Header("Necesary variables")]
    public LayerMask EnemyLayer; // The layer where enemies are located
    public int attackDamage = 10; // Damage for each attack
    [Space(10)]

    [Header("Debug")]
    GameObject enemy;
    bool isAttacking;

    public GameObject tempPrefabNeedsToBeReplacedWithTMPCode;

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

            //if (tempPrefabNeedsToBeReplacedWithTMPCode != null)
            //{
            //    Vector2 damagePopupPos = new Vector2(hitEnemy.transform.position.x, hitEnemy.transform.position.y - 5);
            //    Instantiate(tempPrefabNeedsToBeReplacedWithTMPCode, damagePopupPos, Quaternion.identity);
            //}
        }

        isAttacking = false;
    }
    void OnDrawGizmosSelected()
    {
        // Display the attack range in the editor
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        bool isCorutineStarted = false;
        if (isProjectile && CompareTag("Enemy") && !isCorutineStarted)
        {
            isCorutineStarted = true;
            attackRange = 0;
            attackInterval = 0.1f;
            StartCoroutine(AutoAttack());
        }
    }
}
