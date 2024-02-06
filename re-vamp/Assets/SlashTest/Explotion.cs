using UnityEngine;

public class Explotion: MonoBehaviour
{
    public GameObject prefabToSpawn; // Assign your prefab in the inspector
    public Camera gameCamera; // Assign your main camera in the inspector

    void Update()
    {
        SpawnPrefabAtCameraLook();
    }

    void SpawnPrefabAtCameraLook()
    {
        if (prefabToSpawn != null && gameCamera != null)
        {
            // Assuming the camera is looking directly forward in the 2D plane
            Vector2 spawnPosition = gameCamera.ScreenToWorldPoint(new Vector3(Random.Range(0,Screen.width), Random.Range(0,Screen.height ), gameCamera.nearClipPlane));
            Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Prefab or Camera not assigned!");
        }
    }
}
