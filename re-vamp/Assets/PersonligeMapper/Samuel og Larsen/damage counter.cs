using UnityEngine;
using UnityEngine.UI;

public class DamageIndicator : MonoBehaviour
{
    public GameObject textPrefab; // Assign your UI text prefab
    public Transform spawnPoint;  // The point where the text will appear above the enemy
    public Canvas canvas;         // Assign the main canvas of your UI

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main; // Cache the main camera
    }

    public void ShowDamage(int damageAmount)
    {
        // Convert the spawn point position from world space to screen space
        Vector2 screenPosition = mainCamera.WorldToScreenPoint(spawnPoint.position);

        // Instantiate the text prefab and position it
        GameObject textInstance = Instantiate(textPrefab, screenPosition, Quaternion.identity, canvas.transform);
        textInstance.GetComponent<Text>().text = damageAmount.ToString();

        // Optionally, add animation or movement here

        Destroy(textInstance, 1.0f); // Destroy the text after 1 second
    }

    public void TakeDamage(int damage)
    {

        ShowDamage(damage);
    }
}
                                                                                  