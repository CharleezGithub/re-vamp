using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject[] weaponFields;
    public GameObject[] trinketFields;

    public Weapon weapon;
    public Trinket trinket;

    public GameObject weaponRef;
    public GameObject trinketRef;

    public Vector2 fieldSize;
    public Vector2 spriteSize;

    private void Start()
    {
        InitializeFields(weaponFields, weaponRef);
        InitializeFields(trinketFields, trinketRef);
    }

    void InitializeFields(GameObject[] fields, GameObject referenceObject)
    {
        foreach (GameObject field in fields)
        {
            // Create a new GameObject for the field image
            GameObject fieldImageGO = new GameObject("FieldImage");
            fieldImageGO.transform.SetParent(field.transform); // Set parent

            // Add and configure Image component
            Image fieldImage = fieldImageGO.AddComponent<Image>();
            fieldImage.color = Color.white; // Set the color to white for empty fields
            fieldImage.rectTransform.sizeDelta = fieldSize;

            // Optionally set the position of the fieldImage relative to its parent
            fieldImage.rectTransform.localPosition = Vector3.zero;
            fieldImage.rectTransform.localScale = Vector3.one; // Ensure scale is set to 1

            // Create a new GameObject for the inner image (for weapon/trinket in use)
            GameObject innerImageGO = new GameObject("InnerImage");
            innerImageGO.transform.SetParent(fieldImageGO.transform); // Set parent to the field image

            // Add and configure Image component for inner image
            Image innerImage = innerImageGO.AddComponent<Image>();
            innerImage.rectTransform.sizeDelta = spriteSize;

            // Optionally set the position of the innerImage
            innerImage.rectTransform.localPosition = Vector3.zero;
            innerImage.rectTransform.localScale = Vector3.one; // Ensure scale is set to 1

            // Initially, the inner image can also be set to a default color (transparent or any placeholder color)
            innerImage.color = new Color(1, 1, 1, 0); // Fully transparent
        }
    }
}
