using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public TextMeshProUGUI healthText;
    public Slider healthBar;
    public Vector3 healthBarOffset;
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
        else if (currentHealth > 0)
        {
            healthBar.value = currentHealth;
        }
        HealthBarPosition();
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }

    void HealthBarPosition()
    {
        Camera camera = Camera.main;
        healthBar.transform.rotation = camera.transform.rotation;
        healthBar.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z) + healthBarOffset;
    }
}
