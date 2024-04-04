using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public int XPOrbAmount = 3;
    public GameObject XPOrb;

    public AudioClip PlayOnDeath;

    void Start()
    {
        currentHealth = maxHealth;

    }
    public void Update()
    {
        if (currentHealth <= 0)
        {
            if (PlayOnDeath != null)
                AudioManager.PlaySound(PlayOnDeath, transform.position);

            GetComponent<SpriteRenderer>().sprite = null;

            for (int i = 0; i < XPOrbAmount; i++)
            {
                Instantiate(XPOrb, transform.position + new Vector3(Random.Range(-1,2), Random.Range(-1, 2), 0), Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }
}
