using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [Tooltip("The inventory slots holding the weapons")]
    public Image[] weaponFields;

    [Tooltip("The inventory slots holding the trinkets")]
    public Image[] trinketFields;

    private void Start()
    {
        LevelUpItem();
        ZShop.OnItemBought += AddItem;
    }

    private void AddItem(ZShopItem z)
    {
        Debug.Log("Adding item...");

        ZShopItem[] itemsBought = ZShop.ItemsBought;

        for (int i = 0; i < itemsBought.Length; i++) // Cycles through the bought items
        {
            if (i >= 1 && itemsBought[i - 1].id == itemsBought[i].id)
            {
                LevelUpItem();
                break;
            }

            if (itemsBought[i].SharedProperties.GetItemType() == ItemType.Weapon) // if its a weapon send the weapon sprite to AddWeapon();
            {
                AddWeapon(itemsBought[i].SharedProperties.GetSprite());
                break;
            }

            else if (itemsBought[i].SharedProperties.GetItemType() == ItemType.Trinket) // if its a trinket send the trinket sprite to AddTrinket();
            {
                AddTrinket(itemsBought[i].SharedProperties.GetSprite());
                break;
            }
        }
    }

    private void AddWeapon(Sprite weapon)
    {
        Debug.Log("Adding weapon...");

        for (int i = 0; i < weaponFields.Length; i++) // cycles throught the weapon fields
        {
            if (weaponFields[i].sprite == null) // if a field is empty add the item
            {
                weaponFields[i].sprite = weapon;
                break;
            }
        }
    }

    private void AddTrinket(Sprite trinket)
    {
        Debug.Log("Adding trinket...");

        for (int i = 0; i < trinketFields.Length; i++) // cycles throught the trinket fields
        {
            if (trinketFields[i].sprite == null) // if a field is empty add the item
            {
                trinketFields[i].sprite = trinket;
                break;
            }
        }
    }

    private void LevelUpItem()
    {
        Debug.Log("Duplicate found");
    }
}