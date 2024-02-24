using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class Timer : MonoBehaviour
{
    public int damage = 5;

    public float attackCooldownTime = 1f;
    private bool canAttack;
    private void Start()
    {
        StartCoroutine(AttackCooldown());
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        // Check if the colliding object has the "Player" tag
        if (collision.gameObject.CompareTag("Player") && canAttack)
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(damage);
            
            StartCoroutine(AttackCooldown());
        }
    }
    IEnumerator AttackCooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackCooldownTime);
        canAttack = true;
    }
}