using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject player;
    public LayerMask Layer;
    public float range = 5f;
    public int damage = 1;
    public float cooldown = 1f;

    Collider2D AttackRange;
    bool canAttack;
    private void Start()
    {
        canAttack = true;
    }
    void Update()
    {
        Attacklogic();
    }
    private void Attacklogic()
    {
        AttackRange = Physics2D.OverlapCircle(transform.position, range, Layer);

        if (AttackRange != null && canAttack)
        {
            player.GetComponent<Health>().TakeDamage(damage);
            canAttack = false;
            Invoke(nameof(ResetAttack), cooldown);
        }
    }
    void ResetAttack()
    {
        canAttack = true;
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
