using UnityEngine;
using System.Collections; // Required for IEnumerator

public class Explotion : MonoBehaviour
{
    public GameObject prefabToSpawn; // Assign your prefab in the inspector
    public Camera gameCamera; // Assign your main camera in the inspector
    public float waitTime; // Assign your main camera in the inspector

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnPrefabAtCameraLookRoutine());
    }

    IEnumerator SpawnPrefabAtCameraLookRoutine()
    {
        // Loop indefinitely
        while (true)
        {
            SpawnPrefabAtCameraLook();
            yield return new WaitForSeconds(waitTime); // Wait for 1 second before spawning the next prefab
        }
    }

    void SpawnPrefabAtCameraLook()
    {
        if (prefabToSpawn != null && gameCamera != null)
        {
            // Assuming the camera is looking directly forward in the 2D plane
            Vector2 spawnPosition = gameCamera.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), gameCamera.nearClipPlane));
            Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Prefab or Camera not assigned!");
        }
    }
}
