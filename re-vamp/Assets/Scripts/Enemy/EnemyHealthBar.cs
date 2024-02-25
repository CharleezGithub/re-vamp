using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Slider healthBar;
    EnemyHealth enemyHealth;
    public Vector3 healthBarOffset;

    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        enemyHealth = GetComponentInParent<EnemyHealth>();

        GetComponent<Canvas>().worldCamera = Camera.main;

        healthBar = healthBar.GetComponent<Slider>();

        healthBar.maxValue = enemyHealth.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (healthBar != null)
            healthBar.value = enemyHealth.currentHealth;
        else
            Debug.Log("Healthbar null");
        HealthBarPosition();
    }
    void HealthBarPosition()
    {
        healthBar.transform.SetPositionAndRotation(new Vector3(enemy.transform.position.x, enemy.transform.position.y, enemy.transform.position.z) + healthBarOffset, Camera.main.transform.rotation);
    }
}
