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
    void Start()
    {
        currentHealth = maxHealth;
    }
    public void Update()
    {
        Debug.Log(currentHealth);

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
        if (currentHealth > 0)
        {
            if (healthText != null)
            healthText.text = "Health: " + currentHealth;
            healthBar.value = currentHealth;
        }
        else if (healthText != null && currentHealth <= 0)
            healthText.text = "Health: " + 0;
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }
}
