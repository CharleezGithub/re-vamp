using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public float lifetime = 15f; // Lifetime of the prefab in seconds

    void Start()
    {
        Destroy(gameObject, lifetime);
    }
}
