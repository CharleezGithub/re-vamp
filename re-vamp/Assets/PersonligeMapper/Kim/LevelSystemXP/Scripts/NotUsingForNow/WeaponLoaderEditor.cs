using UnityEngine;
using UnityEditor;
using System.IO;

public class WeaponLoaderEditor : EditorWindow
{
    [SerializeField]private TextAsset jsonFile;

    [MenuItem("Tools/Update Weapon Prefabs")]
    public static void ShowWindow()
    {
        GetWindow<WeaponLoaderEditor>("Update Weapon Prefabs");
    }

    private void OnGUI()
    {
        GUILayout.Label("Load Weapon Data From JSON", EditorStyles.boldLabel);
        jsonFile = (TextAsset)EditorGUILayout.ObjectField("JSON File", jsonFile, typeof(TextAsset), false);

        if (GUILayout.Button("Update Prefabs"))
        {
            if (jsonFile != null)
            {
                UpdateWeaponPrefabs(jsonFile);
            }
            else
            {
                Debug.LogError("No JSON file selected.");
            }
        }
    }

    private static void UpdateWeaponPrefabs(TextAsset jsonFile)
    {
        WeaponCollection weaponCollection = JsonUtility.FromJson<WeaponCollection>(jsonFile.text);
        string[] guids = AssetDatabase.FindAssets("t:GameObject", new[] { "Assets/Resources/Utilities/Weapons" });

        foreach (string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(path);

            if (prefab != null)
            {
                foreach (Weapons weaponData in weaponCollection.weapons)
                {
                    if (prefab.name.Equals(weaponData.name + " Variant"))
                    {
                        GameObject prefabInstance = PrefabUtility.InstantiatePrefab(prefab) as GameObject;
                        Weapons weaponComponent = prefabInstance.GetComponent<Weapons>();

                        if (weaponComponent != null)
                        {
                            //weaponComponent.weaponName = weaponData.name;
                            //weaponComponent.weaponDescription = weaponData.attributes.description;
                            //weaponComponent.weaponItem = weaponData.attributes.item;
                            //weaponComponent.weaponDamage = weaponData.attributes.damage;
                            //weaponComponent.weaponLevel = weaponData.attributes.level;
                            //weaponComponent.weaponLevelMultiplier = weaponData.attributes.levelMultiplier;

                            PrefabUtility.SaveAsPrefabAsset(prefabInstance, path);
                            GameObject.DestroyImmediate(prefabInstance); // Clean up
                            Debug.Log($"Updated prefab {prefab.name}.");
                        }
                        else
                        {
                            Debug.LogError($"Weapon component not found on {prefab.name}.");
                        }
                        break; // Move to the next prefab after a match is found and updated
                    }
                }
            }
        }

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
}
