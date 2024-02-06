using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RandomDamage : MonoBehaviour
{
    public float circleRadius = 5f;
    
    public GameObject damageCircle;


    void Start()
    {
        Vector2 randomPoint = RandomPointInCircle();
        Debug.Log("Random Point: " + randomPoint);
        Instantiate(damageCircle, randomPoint, Quaternion.identity);
    }

    Vector2 RandomPointInCircle()
    {
        float randomAngle = Random.Range(0f, 2f * Mathf.PI);
        float randomRadius = Mathf.Sqrt(Random.Range(0f, 1f)) * circleRadius;

        float x = randomRadius * Mathf.Cos(randomAngle);
        float y = randomRadius * Mathf.Sin(randomAngle);

        return new Vector2(x, y);
    }
}