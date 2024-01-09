using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public int amount = 1000;
    public GameObject nyGameObject; // Assign your prefab in the inspector

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < amount; i++)
        {
            // Generate a random position
            Vector3 randomPosition = new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f), 0);

            // Instantiate the GameObject at the random position
            GameObject nyObjekt = Instantiate(nyGameObject, randomPosition, Quaternion.identity);

            // Set the name of the GameObject
            nyObjekt.name = "Square" + i;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
