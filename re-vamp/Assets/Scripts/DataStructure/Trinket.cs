using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Trinket : MonoBehaviour
{
    public List<TrinketData> allTrinketData = new List<TrinketData>();
    void Awake()
    {
        LoadAllTrinketnData();
    }
    public void LoadAllTrinketnData()
    {
        allTrinketData.Clear(); // Clear the list to avoid duplicates if Start is called multiple times
        // Find all GUIDs of ScriptableObject files of type TrinketData
        string[] guids = AssetDatabase.FindAssets("t:TrinketData");

        foreach (string guid in guids)
        {
            // Get the file path using the GUID
            string assetPath = AssetDatabase.GUIDToAssetPath(guid);

            // Load the ScriptableObject instance at the specified path
            TrinketData trinketData = AssetDatabase.LoadAssetAtPath<TrinketData>(assetPath);

            // Add the loaded TrinketData instance to the list
            allTrinketData.Add(trinketData);
        }
    }
}
