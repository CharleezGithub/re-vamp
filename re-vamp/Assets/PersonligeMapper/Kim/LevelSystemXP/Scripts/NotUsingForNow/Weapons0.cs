using System;
using UnityEngine;

[Serializable]
public class WeaponCollection
{
    public Weapons[] weapons;
}

[Serializable]
public class Weapons
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