using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/DataCollection")]
public class DataCollection : ScriptableObject
{
    public List<WeaponData> weapons = new List<WeaponData>();
    public List<TrinketData> trinkets = new List<TrinketData>();

    #if UNITY_EDITOR
    public void AddWeaponData()
    {
        weapons.Clear();
        // Find all GUIDs of ScriptableObject files of type WeaponData
        string[] guids = AssetDatabase.FindAssets("t:WeaponData");

        foreach (string guid in guids)
        {
            // Get the file path using the GUID
            string assetPath = AssetDatabase.GUIDToAssetPath(guid);

            // Load the ScriptableObject instance at the specified path
            WeaponData weaponData = AssetDatabase.LoadAssetAtPath<WeaponData>(assetPath);

            weapons.Add(weaponData);
        }
    }

    public void AddTrinketData()
    {
        trinkets.Clear();
        // Find all GUIDs of ScriptableObject files of type TrinketData
        string[] guids = AssetDatabase.FindAssets("t:TrinketData");

        foreach (string guid in guids)
        {
            // Get the file path using the GUID
            string assetPath = AssetDatabase.GUIDToAssetPath(guid);

            // Load the ScriptableObject instance at the specified path
            TrinketData trinketData = AssetDatabase.LoadAssetAtPath<TrinketData>(assetPath);

            // Add the loaded TrinketData instance to the list
            trinkets.Add(trinketData);
        }
    }
    #endif
}
