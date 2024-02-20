using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public TextMeshProUGUI healthText;
    public int armour;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(2))
            TakeDamage(10);

        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        if (healthText != null && currentHealth > 0)
        {
            healthText.text = "Health: " + currentHealth;
        }
        else if (healthText != null && currentHealth <= 0)
            healthText.text = "Health: " + 0;
    }

    public void TakeDamage(float damage)
    {
        float damageReduction = (100 + armour) / 100;
        damage = damage / damageReduction;
        currentHealth -= (int)damage;    
    }
    
  
}
