using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public Slider healthBar;
    void Update()
    {
        healthBar.value = GetComponent<Health>().currentHealth;
    }
}
