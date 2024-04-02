using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public float speed = 4.5f;



    private void Update()
    {
       
        transform.position += transform.right * Time.deltaTime * speed;
    }


    
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Physics2D.IgnoreCollision(collision, gameObject.GetComponent<Collider2D>());
            return;
        }
        Destroy(gameObject);
    }

    private void OnCollisionE2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Physics2D.IgnoreCollision(collision.collider, gameObject.GetComponent<Collider2D>());
            return;
        }
        Destroy(gameObject);
    }

}
