using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions;

[CreateAssetMenu(menuName = "Data/TrinketData")]
public class TrinketData : ZItemSO, IZShopItem
{
    public string trinketName;
    public string description;
    public int maxHealthIncrease;
    public int damageIncrease;
    public int armorIncrease;
    public bool itemShopSlotIncrease;
    public float projectileSpeedIncrease;
    public float movementSpeedIncrease;
    public float viewDistanceIncrease;
    public float levelMultiplier;
    public float FOV;
    public GameObject trinketPrefab;

    public Sprite GetSprite()
    {
        if (trinketPrefab == null)
        {
            string path = "NOT IN EDITOR";

#if UNITY_EDITOR
            path = AssetDatabase.GetAssetPath(this);
#endif
            Debug.LogError($"Prefab not assigned! At: {path}\n(Kim, I know you're not reading this, but please just read errors my guy)");

            return null;
        }
        return trinketPrefab.GetComponent<SpriteRenderer>().sprite;
    }

    public string GetName() => trinketName;
    public ItemType GetItemType() => ItemType.Trinket;
    public GameObject GetPrefab() => trinketPrefab;
}
