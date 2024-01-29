using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileEnemyAttack : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject target;
    public float fireInterval = 2f;
    public float projectileSpeed = 5f;
    public float projectileLifetime = 3f;
    Rigidbody2D rb;
    void Start()
    {
        InvokeRepeating("FireProjectile", 0, fireInterval);
    }
    void FireProjectile()
    {
        Vector2 directionToTarget = (target.transform.position - transform.position).normalized;
        GameObject newProjectile = Instantiate(projectile, transform.position, Quaternion.identity);
        rb = newProjectile.GetComponent<Rigidbody2D>();
        rb.velocity = directionToTarget * projectileSpeed;
        Destroy(newProjectile, projectileLifetime);
    }
}
