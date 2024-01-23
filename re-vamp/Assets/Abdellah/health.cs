using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f;
    public static float currentHealth; 
    
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void Update()
    {

        if (currentHealth <= 0)
        {
            //skift scene når det er lavet
        }
    }

}
