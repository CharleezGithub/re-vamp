using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public WeaponData weaponData; // Reference to the ScriptableObject

    // This method is called automatically when the script is loaded
    void Awake()
    {
        // Do whatever you need to do with the loaded WeaponData
        Debug.Log("Weapon Name: " + weaponData.weaponName);
        Debug.Log("Description: " + weaponData.description);
        Debug.Log("Damage: " + weaponData.damage);
        Debug.Log("Level: " + weaponData.level);
        Debug.Log("Level Multiplier: " + weaponData.levelMultiplier);
        Debug.Log("Weapon Prefab: " + weaponData.weaponPrefab);
        Debug.Log(" ");
        UpdateVariablesInData();
    }

    void UpdateVariablesInData()
    {
        // Modify the 'damage' variable of the 'weaponData' ScriptableObject
        if (weaponData != null)
        {
            Debug.Log("Original Damage: " + weaponData.damage);

            // Change the value of the 'damage' variable
            weaponData.damage = 30; // Change this to the desired new value

            Debug.Log("New Damage: " + weaponData.damage);

            // Save changes back to the ScriptableObject asset file
            UnityEditor.EditorUtility.SetDirty(weaponData);
            UnityEditor.AssetDatabase.SaveAssets();
        }
        else
        {
            Debug.LogError("WeaponData is not assigned!");
        }
    }
}

