using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;    
    void Start()
    {
        currentHealth = maxHealth;
        
    }
    public void Update()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }        
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        Destroy(collision.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }

}
