using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trinket : MonoBehaviour
{
    public TrinketData trinketData;
    void Awake()
    {
        // Do whatever you need to do with the loaded WeaponData
        Debug.Log("trinket Name: " + trinketData.trinketName);
    }
}
