using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public int amount = 1000;
    public GameObject nyGameObject; 


    void Start()
    {
        for (int i = 0; i < amount; i++)
        {
           
            Vector3 randomPosition = new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f), 0);

            
            GameObject nyObjekt = Instantiate(nyGameObject, randomPosition, Quaternion.identity);

           
            nyObjekt.name = "Square" + i;

            nyObjekt.AddComponent<Rigidbody2D>();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
