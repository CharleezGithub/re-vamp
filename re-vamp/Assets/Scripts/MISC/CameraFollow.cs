using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.3f;

    private Vector3 velocity = Vector3.zero;
    private float cameraOriginalZ;

    private void Start()
    {
        cameraOriginalZ = transform.position.z;
    }

    private void FixedUpdate()
    {
        if (target != null)
        {
            Vector3 targetPosition = target.position;
            targetPosition.z = cameraOriginalZ;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
        else
        {
            Debug.LogWarning("CameraFollow script on " + gameObject.name + " has no target set.");
        }
    }
}
