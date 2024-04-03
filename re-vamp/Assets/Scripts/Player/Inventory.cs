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
        ZShop.OnItemBought += AddItem;
    }

    private void AddItem(ZShopItem itemBought)
    {
        Debug.Log("Adding item...");


        if (itemBought.SharedProperties.GetItemType() == ItemType.Weapon && itemBought.level == 0) // if its a weapon send the weapon sprite to AddWeapon();
        {
            AddWeapon(itemBought.SharedProperties.GetSprite());
        }

        else if (itemBought.SharedProperties.GetItemType() == ItemType.Trinket && itemBought.level == 0) // if its a trinket send the trinket sprite to AddTrinket();
        {
            AddTrinket(itemBought.SharedProperties.GetSprite());
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
}