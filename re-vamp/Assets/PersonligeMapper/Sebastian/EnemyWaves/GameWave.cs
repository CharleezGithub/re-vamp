using System.Collections;
using UnityEngine;

public class GameWave : MonoBehaviour
{
    public float timer = 0f;
    public float WaveTime = 20f;
    public GameObject[] Enemies;
    public int Wave = 0;
    public float radius;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > WaveTime)
        {
            SpawnWave(Wave);
            timer = 0f;
            Wave++;
        }
    }

    private void SpawnWave(int Difficulty)
    {
      while (Difficulty > 0)
        {
            int EnemyIndex = UnityEngine. Random.Range(0, Enemies.Length);
            var EnemyToSpawn = Enemies[EnemyIndex];

            SpawnCircle(Difficulty, EnemyToSpawn);
            Difficulty -= 1;
        }
    }
    void SpawnCircle(int numberOfObjects, GameObject objectToSpawn)
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            // Generate a random angle between 0 and 360 degrees
            float angle = Random.Range(0f, 360f);
            // Convert angle to radians and calculate x and y position
            float x = Mathf.Cos(angle * Mathf.Deg2Rad) * radius;
            float y = Mathf.Sin(angle * Mathf.Deg2Rad) * radius;
            // Determine the position to spawn the object
            Vector3 spawnPosition = transform.position + new Vector3(x, y, 0); // Adjust y to your needs, depending on the orientation of your game
            // Spawn the object
            Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
        }
    }

}
