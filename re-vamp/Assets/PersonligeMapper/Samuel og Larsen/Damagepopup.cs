using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePopup : MonoBehaviour
{
    public static DamagePopup current;

    public GameObject prefab;

    public void Awake()
    {
        current = this;
    }
    public static void CreatePopUp(Vector3 position, string text) // Correct method name
    {
        var popup = Instantiate(current.prefab, position, Quaternion.identity);
        var tmp = popup.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        tmp.text = text;
        Destroy(popup, 1f);
    }

}