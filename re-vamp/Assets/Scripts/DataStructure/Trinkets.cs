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
    public int max_health_incease { get; set; }
    public int damage_increase { get; set; }
    public int projectile_speed_increase { get; set; }
    public int movement_speed_increase { get; set; }
    public int armor_increase { get; set; }
    public int item_shop_slot_increase { get; set; }
    public int view_distance_increase { get; set; }
    public string description { get; set; }
    public string item { get; set; }
}
