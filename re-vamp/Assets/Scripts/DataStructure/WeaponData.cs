using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/WeaponData")]
public class WeaponData : ScriptableObject, IZShopItem
{
    public string weaponName;
    public string description;
    public int damage;
    public int level;
    public float levelMultiplier;
    public GameObject weaponPrefab;

    public Sprite GetSprite() => weaponPrefab.GetComponent<SpriteRenderer>().sprite;
    public string GetName() => weaponName;
}

