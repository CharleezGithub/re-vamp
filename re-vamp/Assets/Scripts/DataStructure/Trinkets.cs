using System;
using UnityEngine;

[Serializable]
public class TrinketCollection
{
    public Trinket[] trinkets;
}

[Serializable]
public class Trinket
{
    public string name;
    public Attributes attributes;
}

[Serializable]
public class Attributes
{
    public int level;
    public int maxHealthIncrease;
    public int damageIncrease;
    public int armorIncrease;
    public int itemShopSlotIncrease;
    public float projectileSpeedIncrease;
    public float movementSpeedIncrease;
    public float viewDistanceIncrease;
    public float levelMultiplier;
    public string description;
    public string item;
}
