using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [Tooltip("The inventory slots holding the weapons")]
    public GameObject[] weaponFields;

    [Tooltip("The inventory slots holding the trinkets")]
    public GameObject[] trinketFields;

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
        ZShop.OnItemBought += AddItem;
    }

    private void AddItem(ZShopItem item)
    {
        if (item.TrinketOrWeapon)
        {
            for (int i = 0; i < trinketFields.Length; i++)
            {
                if (trinketFields[i].GetComponentInChildren<Image>().sprite == null)
                {
                    //trinketFields[i].GetComponentInChildren<Image>().sprite = item
                }
            }
        }
        else if (!item.TrinketOrWeapon)
        {
            for (int i = 0; i < weaponFields.Length; i++)
            {
                if (weaponFields[i].GetComponentInChildren<Image>().sprite == null)
                {

                }
            }
        }
    }
}
