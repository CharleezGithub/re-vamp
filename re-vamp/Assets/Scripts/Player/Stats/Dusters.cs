using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dusters : MonoBehaviour
{
    Attack attack_script;

    public float damage_multiplier = 1.6f;

    void OnEnable()
    {
        attack_script = Player.Instance.GetComponent<Attack>();

        attack_script.attackDamage *= damage_multiplier;
    }

    void OnDisable()
    {
        attack_script.attackDamage /= damage_multiplier;
    }
}
