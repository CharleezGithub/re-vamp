using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boots : MonoBehaviour
{

    public PlayerMovement move_script;

    public float speed_multiplier = 1.4f;

    void OnEnable()
    {
        move_script.moveSpeed *= speed_multiplier;
    }
    void OnDisable()
    {
        move_script.moveSpeed /= speed_multiplier;
    }


    // Update is called once per frame
    void Update()
    {

    }
}
