using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class allTrinkets
{
    public Trinket[] trinkets { get; set; }
}

public class Trinket
{
    public string name { get; set; }
    public attribute attributes { get; set; }
}

public class attribute
{
    public int level { get; set; }
    public int max_health_increase { get; set; }
    public int damage_increase { get; set; }
    public int armor_increase { get; set; }
    public int item_shop_slot_increase { get; set; }
    public float projectile_speed_increase { get; set; }
    public float movement_speed_increase { get; set; }
    public float view_distance_increase { get; set; }
    public float level_multiplier { get; set; }
    public string description { get; set; }
    public string item { get; set; }
}
