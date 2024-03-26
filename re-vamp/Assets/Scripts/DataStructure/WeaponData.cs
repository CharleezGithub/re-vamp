using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions;

[CreateAssetMenu(menuName = "Data/WeaponData")]
public class WeaponData : ScriptableObject, IZShopItem
{
    public string weaponName;
    public string description;
    public int damage;
    public int level;
    public float levelMultiplier;
    public GameObject weaponPrefab;

    public Sprite GetSprite()
    {
        if (weaponPrefab == null)
        {
            string path = AssetDatabase.GetAssetPath(this);
            Debug.LogError("Prefab not assigned! At: " + path);
            return null;
        }
        return weaponPrefab.GetComponent<SpriteRenderer>().sprite;
    }

    public string GetName() => weaponName;

    public ItemType GetItemType() => ItemType.Weapon;
}

