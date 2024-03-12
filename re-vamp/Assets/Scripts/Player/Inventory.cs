using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [Tooltip("Reference to the empty GameObject holding the weaponFields")]
    public GameObject weaponFields;
    [Tooltip("Reference to the empty GameObject holding the trinketFields")]
    public GameObject trinketFields;
    [Tooltip("Reference to weapon script")]
    [SerializeField] private GameObject weaponRef;
    [Tooltip("Reference to trinket script")]
    [SerializeField] private GameObject trinketRef;
    [Tooltip("x and y size of the fields")]
    public Vector2 fieldSize = new Vector2(100, 100);
    [Tooltip("x and y size of the sprites inside the inventory slot")]
    public Vector2 spriteFieldSize = new Vector2(80, 80);
    [Tooltip("Offset between weapon fields")]
    public Vector2 weaponOffset = new Vector2(110, 0);
    [Tooltip("Offset between trinket fields")]
    public Vector2 trinketOffset = new Vector2(0, -110);
    [Tooltip("The background sprite for each field")]
    public Sprite fieldSprite;

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
            foreach (var weaponData in weaponComponent.allWeaponData) // create a inventory field fo each weapon existing
            {
                CreateInventoryItem(null, true, weaponFields.transform, ref currentWeaponPosition, weaponOffset);
            }
        }

        Trinket trinketComponent = trinketRef.GetComponent<Trinket>();
        if (trinketComponent != null)
        {
            foreach (var trinketData in trinketComponent.allTrinketData) // create a inventory field fo each trinket existing
            {
                CreateInventoryItem(null, false, trinketFields.transform, ref currentTrinketPosition, trinketOffset);
            }
        }
    }
    public void AddItem(Sprite itemSprite, bool isWeapon)
    {
        Transform parentObject = isWeapon ? weaponFields.transform : trinketFields.transform;
        bool itemAdded = false;

        // Iterate over each field to find the first one without an item sprite or to detect duplicates
        for (int i = 0; i < parentObject.childCount; i++)
        {
            Transform fieldTransform = parentObject.GetChild(i);

            Image itemImage = fieldTransform.GetChild(0).GetComponent<Image>();

            if (itemImage != null && !itemAdded)
            {
                if (itemImage.sprite == null || itemImage.sprite == fieldSprite)
                {
                    // This field is empty, so we can add the item here
                    itemImage.sprite = itemSprite;
                    itemImage.rectTransform.sizeDelta = spriteFieldSize;
                    itemAdded = true;
                    break; // Stop searching once we've added the item
                }
                else if (itemImage.sprite == itemSprite)
                {
                    Debug.Log("Duplicate item detected."); // TODO: handle duplicates
                    break;
                }
            }
            else if (itemImage == null)
            {

            }
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
