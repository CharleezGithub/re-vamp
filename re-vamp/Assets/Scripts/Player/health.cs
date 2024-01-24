using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public TextMeshProUGUI healthText;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void Update()
    {
        if (currentHealth <= 0)
        {
            // Game Over
        }
        if (healthText != null && currentHealth > 0)
        {
            healthText.text = "Health: " + currentHealth;
        }
        else if (healthText != null && currentHealth <= 0)
            healthText.text = "Health: " + 0;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;    
    }
}
