using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Syringe : MonoBehaviour
{
    public Attack attack_script;

    public float proj_speed_multiplier = 1.6f;

    void OnEnable()
    {
        attack_script.projectileAttackInterval *= proj_speed_multiplier;
    }
    void OnDisable()
    {
        attack_script.projectileAttackInterval /= proj_speed_multiplier;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
