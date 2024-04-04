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
        GameObject popup = Instantiate(current.prefab, position, Quaternion.identity);
        TextMeshProUGUI tmp = popup.transform.GetComponent<TextMeshProUGUI>();
        tmp.text = text;

        print(text);
        print(tmp);

        Destroy(popup, 1f);
    }

}