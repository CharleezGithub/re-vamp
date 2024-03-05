using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject weaponRef; // Reference to the GameObject containing the Weapon script and parent to weapon fields
    public GameObject trinketRef; // Reference to the GameObject containing the Trinket script and parent to trinket fields

    public Vector2 fieldSize = new Vector2(100, 100); // Default field size
    public Vector2 spriteSize = new Vector2(80, 80); // Default sprite size
    public Vector2 weaponOffset = new Vector2(110, 0); // Offset for weapon fields
    public Vector2 trinketOffset = new Vector2(0, -110); // Offset for trinket fields

    public Sprite fieldSprite; // The background sprite for each field

    private void Start()
    {
        InitializeFields();
    }
    private void InitializeFields()
    {
        Vector2 currentWeaponPosition = Vector2.zero; // Start position for weapon fields
        Vector2 currentTrinketPosition = Vector2.zero; // Start position for trinket fields

        Weapon weaponComponent = weaponRef.GetComponent<Weapon>();
        if (weaponComponent != null)
        {
            foreach (var weaponData in weaponComponent.allWeaponData)
            {
                CreateInventoryItem(null, true, weaponRef.transform, ref currentWeaponPosition, weaponOffset);
            }
        }

        Trinket trinketComponent = trinketRef.GetComponent<Trinket>();
        if (trinketComponent != null)
        {
            foreach (var trinketData in trinketComponent.allTrinketData)
            {
                CreateInventoryItem(null, false, trinketRef.transform, ref currentTrinketPosition, trinketOffset);
            }
        }
    }
    public void AddItem(Sprite itemSprite, bool isWeapon)
    {
        Transform parentObject = isWeapon ? weaponRef.transform : trinketRef.transform;
        bool itemAdded = false;
        bool duplicateFound = false;

        // Iterate over each field to find the first one without an item sprite or to detect duplicates
        for (int i = 0; i < parentObject.childCount; i++)
        {
            Transform fieldTransform = parentObject.GetChild(i);

            // Assuming each field has exactly one child used for the item image
            if (fieldTransform.childCount > 0)
            {
                Image itemImage = fieldTransform.GetChild(0).GetComponent<Image>();
                if (itemImage != null)
                {
                    if (itemImage.sprite == null || itemImage.sprite == fieldSprite)
                    {
                        // This field is empty, so we can add the item here
                        itemImage.sprite = itemSprite;
                        itemImage.rectTransform.sizeDelta = spriteSize;
                        itemAdded = true;
                        break; // Stop searching once we've added the item
                    }
                    else if (itemImage.sprite == itemSprite)
                    {
                        // Found a duplicate
                        duplicateFound = true;
                        break;
                    }
                }
            }
            else
            {
                var trinketScript = trinketRef.GetComponent<Trinket>();
                GameObject prefab = trinketScript.allTrinketData[i].trinketPrefab;

                Instantiate(prefab, Vector2.zero, Quaternion.identity, fieldTransform);

                break; // Item added, no need to continue
            }
        }

        if (duplicateFound)
        {
            Debug.Log("Duplicate item detected.");
        }
        else if (!itemAdded)
        {
            Debug.Log("All fields are occupied.");
            // Handle the case when all fields are occupied even tho it is not suposed to happen
        }
    }

    void CreateInventoryItem(Sprite itemSprite, bool isWeapon, Transform parentObject, ref Vector2 currentPosition, Vector2 offset)
    {
        GameObject fieldGO = new GameObject(isWeapon ? "WeaponField" : "TrinketField", typeof(Image));
        fieldGO.transform.SetParent(parentObject, false);
        fieldGO.GetComponent<Image>().sprite = fieldSprite;

        RectTransform fieldRect = fieldGO.GetComponent<RectTransform>();
        fieldRect.sizeDelta = fieldSize;
        fieldRect.anchoredPosition = currentPosition;

        currentPosition += offset;
    }
}
