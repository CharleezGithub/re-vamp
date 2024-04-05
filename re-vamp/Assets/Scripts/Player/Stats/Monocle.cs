using Cinemachine;
using UnityEngine;

public class Monocle : MonoBehaviour
{
    public float fovMultiplier = 1.4f;

    private void OnEnable()
    {

    }

    private void OnDisable()
    {
        if (virtualCamera != null && cinemachineBrain != null)
        {
            // Reset the FOV to its original value when disabling
            virtualCamera.m_Lens.FieldOfView /= fovMultiplier;
        }
        else
        {
            Debug.LogWarning("Camera or CinemachineBrain not found. Make sure your camera is tagged as 'VirtualCamera'.");
        }
    }

}
