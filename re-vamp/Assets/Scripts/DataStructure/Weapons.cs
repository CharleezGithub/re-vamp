using System;
using UnityEngine;

[Serializable]
public class WeaponCollection
{
    public Weapon[] weapons;
}

[Serializable]
public class Weapon
{
    public string name;
    public WeaponAttributes attributes;
}

[Serializable]
public class WeaponAttributes
{
    public string description;
    public string item;
    public int damage;
    public int level;
    public float levelMultiplier;
}