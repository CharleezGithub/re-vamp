using UnityEngine;
using System.Collections;

public class Explotion : MonoBehaviour
{
    public Bounds SpawnBounds;
    public GameObject prefabToSpawn; // Assign your prefab in the inspector
    public float minScale = 0.1f; // Minimum scale of the prefab
    public float maxScale = 0.5f; // Maximum scale of the prefab
    public float minimumDistance = 3.0f; // Minimum distance from the player
    public float timeBetweenExplotions = 5.0f; // Minimum distance from the player


    public float yOffset = 30.0f;

    void Start()
    {
        StartCoroutine(SpawnPrefabAtCameraLookRoutine());
    }

    IEnumerator SpawnPrefabAtCameraLookRoutine()
    {
        while (true)
        {
            SpawnPrefabAtRandomScreenPos();
            yield return new WaitForSeconds(timeBetweenExplotions); // Wait for 1 second before spawning the next prefab
        }
    }

    void SpawnPrefabAtRandomScreenPos()
    {
        var spawnPosition = GetRandomPositionWithinBounds();
        GameObject spawnedPrefab = Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);

        print(spawnPosition);
        spawnedPrefab.transform.eulerAngles = new Vector3(
        spawnedPrefab.transform.eulerAngles.x - 90,
        spawnedPrefab.transform.eulerAngles.y,
        spawnedPrefab.transform.eulerAngles.z
        );
    }

    private Vector3 GetRandomPositionWithinBounds()
    {
        // Generate random x, y, and z coordinates within the bounds
        float randomX = Random.Range(SpawnBounds.min.x, SpawnBounds.max.x);
        float randomY = Random.Range(SpawnBounds.min.y, SpawnBounds.max.y);

        // Return the random position
        return new Vector3(randomX, randomY, 0);
    }
}
