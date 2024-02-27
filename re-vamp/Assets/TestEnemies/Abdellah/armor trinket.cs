using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armortrinket : MonoBehaviour
{

    public GameObject Player;
    public int armorBoostAmount = 20;
    void Start()
    {

    }

 
    public void BuyArmorTrinket()
    {
       
        Health playerHealth = Player.GetComponent<Health>();

        if (playerHealth != null)
        {
            playerHealth.ArmorBoost(armorBoostAmount);
            
        }
    }
}
