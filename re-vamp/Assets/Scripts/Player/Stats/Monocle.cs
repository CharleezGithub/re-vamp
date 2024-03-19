using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monocle : MonoBehaviour
{
    public float fov_multiplier = 1.4f;



    void OnEnable()
    {
        Camera mainCamera = Camera.main;
        // Check if a main camera is found to avoid null reference exceptions
        if (mainCamera != null)
        {
            mainCamera.fieldOfView *= fov_multiplier;
        }
        else
        {
            Debug.LogWarning("Main Camera not found. Make sure your camera is tagged as 'MainCamera'.");
        }

    }
    void OnDisable()
    {
        Camera mainCamera = Camera.main;
        // Check if a main camera is found to avoid null reference exceptions
        if (mainCamera != null)
        {
            mainCamera.fieldOfView /= fov_multiplier;
        }
        else
        {
            Debug.LogWarning("Main Camera not found. Make sure your camera is tagged as 'MainCamera'.");
        }

    }
}
