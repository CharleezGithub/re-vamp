using UnityEngine;

public class WeaponLoader : MonoBehaviour
{
    public TextAsset jsonFile;
    public GameObject[] weaponPrefabs; // Assign this in the Inspector

    void Start()
    {
        LoadWeapons();
    }

    void LoadWeapons()
    {
        if (jsonFile != null)
        {
            WeaponCollection weaponCollection = JsonUtility.FromJson<WeaponCollection>(jsonFile.text);

            foreach (Weapons weapon in weaponCollection.weapons)
            {
                foreach (GameObject prefab in weaponPrefabs)
                {
                    if (prefab.name == weapon.name) // Assumes prefab name matches the weapon name
                    {
                        GameObject weaponInstance = Instantiate(prefab, transform.position, Quaternion.identity); // Adjust position as needed
                        Weapon weaponScript = weaponInstance.GetComponent<Weapon>();

                        if (weaponScript != null)
                        {
                            // Apply attributes from JSON
                            //weaponScript.weaponName = weapon.name;
                            //weaponScript.weaponDescription = weapon.attributes.description;
                            //weaponScript.weaponItem = weapon.attributes.item;
                            //weaponScript.weaponDamage = weapon.attributes.damage;
                            //weaponScript.weaponLevel = weapon.attributes.level;
                            //weaponScript.weaponLevelMultiplier = weapon.attributes.levelMultiplier;
                        }
                        break; // Break since we found our match
                    }
                }
            }
        }
        else
        {
            Debug.LogError("JSON file not assigned.");
        }
    }
}

