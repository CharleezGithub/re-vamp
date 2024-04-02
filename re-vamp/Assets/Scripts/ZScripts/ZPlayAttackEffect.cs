using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZPlayAttackEffect : MonoBehaviour
{
    public GameObject EffectPrefab;
    public Camera targetCamera; // Public variable to assign a specific camera
    public float zPosition = 10f; // Distance from the camera

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
        if (targetCamera != null)
        {
            // Convert viewport space (normalized coordinates) to world space using the assigned camera
            Vector3 randomPosition = targetCamera.ViewportToWorldPoint(new Vector3(Random.Range(0f, 1f), Random.Range(0f, 1f), zPosition));

            // Instantiate the prefab with a rotation of -90 degrees around the x axis
            Quaternion rotation = Quaternion.Euler(-90, 0, 0);
            Instantiate(EffectPrefab, randomPosition, rotation);
        }
    }
}