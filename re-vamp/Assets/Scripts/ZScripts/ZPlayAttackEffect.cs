using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZPlayAttackEffect : MonoBehaviour
{
    public GameObject EffectPrefab;

    private void OnEnable()
    {
        Attack.OnPlayerAutoAttack += Attack_OnPlayerAutoAttack;
    }

    private void OnDisable()
    {
        Attack.OnPlayerAutoAttack -= Attack_OnPlayerAutoAttack;
    }

    private void Attack_OnPlayerAutoAttack()
    {
        Instantiate(EffectPrefab, transform.position, Quaternion.identity);
    }
}
