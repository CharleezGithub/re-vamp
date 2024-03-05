using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePopup : MonoBehaviour
{
    public float fadeDuration = 1.5f; // Time in seconds for the text to completely fade out.
    public float moveSpeed = 1f; // Speed at which the text moves up.

    private TextMeshPro textMesh;
    private float fadeSpeed;
    private Color textColor;

    private void Awake()
    {
        textMesh = transform.GetComponent<TextMeshPro>();
    }

    public void Setup(int damageAmount)
    {
        textMesh.text = damageAmount.ToString();
        textColor = textMesh.color;
        fadeSpeed = 1 / fadeDuration; // Calculate the fade speed based on the duration.
    }

    private void Update()
    {
        // Move the damage text up.
        transform.position += new Vector3(0, moveSpeed * Time.deltaTime, 0);

        // Fade out the text over time.
        textColor.a -= fadeSpeed * Time.deltaTime;
        textMesh.color = textColor;

        if (textColor.a <= 0)
        {
            Destroy(gameObject); // Destroy the object when fully faded.
        }
    }

}