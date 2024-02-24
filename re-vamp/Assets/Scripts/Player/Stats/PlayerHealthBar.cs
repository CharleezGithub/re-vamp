using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public Slider healthBar;
    public Health health;
    private void Update()
    {
        healthBar.value = health.currentHealth;
        healthBar.maxValue = health.maxHealth;
    }
}
