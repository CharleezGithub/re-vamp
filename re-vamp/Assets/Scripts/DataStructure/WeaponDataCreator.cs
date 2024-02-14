using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Data/WeaponData")]
public class WeaponDataCreator : ScriptableObject
{
    public string weaponName;
    public string description;
    public int damage;
    public int level;
    public float levelMultiplier;
    public GameObject weaponPrefab;
}
