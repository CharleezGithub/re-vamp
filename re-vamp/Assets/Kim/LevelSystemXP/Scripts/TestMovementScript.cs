using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovementScript : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
    }
    void Movement()
    {
        rb.AddForce(new Vector2 (Input.GetAxisRaw("Horizontal") * speed / 2, Input.GetAxisRaw("Vertical")) * speed * 10, ForceMode2D.Force);
    }    
}
