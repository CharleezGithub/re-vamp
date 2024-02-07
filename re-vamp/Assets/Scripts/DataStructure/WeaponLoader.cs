using UnityEngine;

public class WeaponLoader : MonoBehaviour
{
    public TextAsset jsonFile;

    void Start()
    {
        LoadWeapons();
    }

    void LoadWeapons()
    {
        if (jsonFile != null)
        {
            WeaponCollection weaponCollection = JsonUtility.FromJson<WeaponCollection>(jsonFile.text);

            foreach (Weapon weapon in weaponCollection.weapons)
            {
                Debug.Log($"Loaded Trinket: {weapon.name}, Level: {weapon.attributes.level}");

                // Here you can instantiate GameObjects or assign values to them based on the trinket data
                // For example, creating a new GameObject for each trinket or finding existing ones and setting their properties
            }
        }
        else
        {
            Debug.LogError("JSON file not assigned.");
        }
    }
}
