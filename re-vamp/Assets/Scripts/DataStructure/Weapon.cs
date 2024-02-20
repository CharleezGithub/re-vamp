using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public List<WeaponData> allWeaponData = new List<WeaponData>();
    public Shop script;

    void Awake()
    {
        LoadAllWeaponData();
    }
    public void LoadAllWeaponData()
    {
        allWeaponData.Clear();

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
        //Sprite[] sprites = allWeaponData.Select(x => x.weaponPrefab.GetComponent<SpriteRenderer>().sprite).ToArray();
        //script.sprites = sprites;
    }
}

