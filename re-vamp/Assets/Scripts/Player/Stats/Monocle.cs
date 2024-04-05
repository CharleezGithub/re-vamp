using Cinemachine;
using UnityEngine;

public class Monocle : MonoBehaviour
{
    public float fovMultiplier = 1.4f;

    private CinemachineVirtualCamera virtualCamera;
    private CinemachineBrain cinemachineBrain;

    private void Awake()
    {
        // Find the virtual camera and cinemachine brain in the scene
        virtualCamera = GameObject.FindWithTag("VirtualCamera").GetComponent<CinemachineVirtualCamera>();
        cinemachineBrain = Camera.main.GetComponent<CinemachineBrain>();
    }

    private void OnEnable()
    {
        if (virtualCamera != null && cinemachineBrain != null)
        {
            // Directly modify the virtual camera's FOV when enabling
            virtualCamera.m_Lens.FieldOfView *= fovMultiplier;
        }
        else
        {
            Debug.LogWarning("Camera or CinemachineBrain not found. Make sure your camera is tagged as 'VirtualCamera'.");
        }
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
