using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashingAttack : MonoBehaviour
{
    [SerializeField] private GameObject slashProjectile;
    public float cooldownTime;
    private void Update()
    {
        StartCoroutine(SlashAttack());
    }

    private IEnumerator SlashAttack()
    {
        yield return new WaitForSeconds(cooldownTime);

    }
}
