using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hearts_increase : MonoBehaviour
{
    public Health health_script;

    public float health_multiplier = 1.5f;

    void OnEnable()
    {
        health_script.maxHealth *= health_multiplier;
    }
    void OnDisable()
    {
        health_script.maxHealth /= health_multiplier;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
