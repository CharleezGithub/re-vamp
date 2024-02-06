using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position : MonoBehaviour
{
    public Transform player;
    public Transform Orbit;
    public Transform Child;
   
    public float x = 2f;
    // Start is called before the first frame update
    void Start()
    {
        Child.position = new Vector3(Orbit.position.x + x, Orbit.position.y, Orbit.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null && Orbit != null) 
        {
        Orbit.position = new Vector3(player.position.x, player.position.y, player.position.z);
            
            
        }
    }
}
