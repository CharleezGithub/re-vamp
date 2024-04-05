using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions;

[CreateAssetMenu(menuName = "Data/WeaponData")]
public class WeaponData : ZItemSO, IZShopItem
{
    public string weaponName;
    public string description;
    public int damage;
    public float levelMultiplier;
    public GameObject weaponPrefab;

    public Sprite GetSprite()
    {
        if (weaponPrefab == null)
        {
            string path = "NOT IN EDITOR";

#if UNITY_EDITOR
            path = AssetDatabase.GetAssetPath(this);
#endif

            Debug.LogError($"Prefab not assigned! At: {path}\n(Kim, I know you're not reading this, but please just read errors my guy)");

            return null;
        }
        return weaponPrefab.GetComponent<SpriteRenderer>().sprite;
    }

    public string GetName() => weaponName;

    public ItemType GetItemType() => ItemType.Weapon;
    public GameObject GetPrefab() => weaponPrefab;
}

