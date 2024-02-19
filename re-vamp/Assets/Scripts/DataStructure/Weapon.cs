using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public WeaponData weaponData; // Reference to the ScriptableObject
    public List<WeaponData> allWeaponData = new List<WeaponData>();
    void Awake()
    {
        LoadAllWeaponData();        
    }
    void LoadAllWeaponData()
    {
        allWeaponData.Clear(); // Clear the list to avoid duplicates if Start is called multiple times

        // Find all GUIDs of ScriptableObject files of type WeaponData
        string[] guids = AssetDatabase.FindAssets("t:WeaponData");

        foreach (string guid in guids)
        {
            // Get the file path using the GUID
            string assetPath = AssetDatabase.GUIDToAssetPath(guid);

            // Load the ScriptableObject instance at the specified path
            WeaponData weaponData = AssetDatabase.LoadAssetAtPath<WeaponData>(assetPath);

            // Add the loaded WeaponData instance to the list
            allWeaponData.Add(weaponData);
        }
    }
}

