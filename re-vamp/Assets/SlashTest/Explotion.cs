using UnityEngine;
using System.Collections;

public class Explotion : MonoBehaviour
{
    public GameObject prefabToSpawn; // Assign your prefab in the inspector
    public Camera gameCamera; // Assign your main camera in the inspector
    public float minScale = 0.5f; // Minimum scale of the prefab
    public float maxScale = 2.0f; // Maximum scale of the prefab
    public float minimumDistance = 3.0f; // Minimum distance from the player
    public float timeBetweenExplotions = 0.1f; // Minimum distance from the player

    void Start()
    {
        StartCoroutine(SpawnPrefabAtCameraLookRoutine());
    }

    IEnumerator SpawnPrefabAtCameraLookRoutine()
    {
        while (true)
        {
            SpawnPrefabAtCameraLook();
            yield return new WaitForSeconds(timeBetweenExplotions); // Wait for 1 second before spawning the next prefab
        }
    }

    void SpawnPrefabAtCameraLook()
    {
        if (prefabToSpawn != null && gameCamera != null)
        {
            Vector2 spawnPosition;
            float distance;
            do
            {
                spawnPosition = gameCamera.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), gameCamera.nearClipPlane));
                distance = Vector2.Distance(spawnPosition, this.transform.position);
            } while (distance < minimumDistance); // Keep looking for a spawn position until it's far enough from the player

            Debug.Log(distance);
            GameObject spawnedPrefab = Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);

             //Randomly scale the prefab
            float scale = Random.Range(minScale, maxScale);
            spawnedPrefab.transform.localScale = new Vector3(scale, scale, 1); // Assuming a uniform scale in 2D
        }
        else
        {
            gameCamera = Camera.main;
            if (prefabToSpawn == null || gameCamera == null)
            Debug.LogError("Prefab, Camera, or Player position not set correctly!");
        }
    }

}
