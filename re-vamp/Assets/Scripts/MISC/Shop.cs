using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

public class Shop : MonoBehaviour
{
    public TextMeshProUGUI[] textSlots;
    public Sprite[] slotContent;
    public GameObject[] slots;

    public Weapon weapon;
    public Trinket trinket;

    public bool fourthSlotActivated;
    public GameObject shop;

    public Inventory inventory;

    int[] itemIndex;
    int selectedField;
    Sprite[] sprites;

    private void Update()
    {
        // TODO: remove this (use only for debugging)
        if (Input.GetKeyDown(KeyCode.F))
            ShowShop(true);
    }
    void Awake()
    {
        if (shop.activeSelf)
            shop.SetActive(false);
    }
    public void ShowShop(bool active)
    {
        slots[3].SetActive(fourthSlotActivated);
        shop.SetActive(active);
        RefreshShop();
    }
    void RefreshShop()
    {
        int slotCount = fourthSlotActivated ? 3 : 2;
        LoadSpritesAndText(slotCount, weapon.allWeaponData.Count, trinket.allTrinketData.Count);
    }
    void LoadSpritesAndText(int slotCount, int weaponCount, int trinketCount)
    {
        var items = new Item[weaponCount + trinketCount];
        itemIndex = new int[slotCount + 1];
        itemIndex[0] = GetRandomIntInRange(weaponCount);
        slotContent[0] = weapon.allWeaponData[itemIndex[0]].weaponPrefab.GetComponent<SpriteRenderer>().sprite;
        textSlots[0].text = weapon.allWeaponData[itemIndex[0]].weaponName;

        for (int i = 1; i <= slotCount; i++)
        {
            if (trinketCount >= weaponCount)
            {
                IfMoreTrinkets(i, weaponCount, trinketCount);
            }
            else
            {
                IfMoreWeapons(i, trinketCount, weaponCount);
            }
        }
    }
    void IfMoreWeapons(int i, int weaponCount, int trinketCount)
    {
        if (GetRandomIntInRange(weaponCount) >= trinketCount)
        {
            itemIndex[i] = GetRandomIntInRange(trinketCount);
            for (int j = 0; j <= i; j++)
            {
                if (slotContent[j] == trinket.allTrinketData[itemIndex[i]].trinketPrefab)
                {
                    itemIndex[i] = GetRandomIntInRange(trinketCount);
                    j--;
                }
            }
            slotContent[i] = trinket.allTrinketData[itemIndex[i]].trinketPrefab.GetComponent<SpriteRenderer>().sprite;
            textSlots[i].text = trinket.allTrinketData[itemIndex[i]].trinketName;
        }
        else
        {
            itemIndex[i] = GetRandomIntInRange(weaponCount);
            for (int j = 0; j <= i; j++)
            {
                if (slotContent[j] == weapon.allWeaponData[itemIndex[i]].weaponPrefab)
                {
                    itemIndex[i] = GetRandomIntInRange(weaponCount);
                    j--;
                }
            }
            slotContent[i] = weapon.allWeaponData[itemIndex[i]].weaponPrefab.GetComponent<SpriteRenderer>().sprite;
            textSlots[i].text = weapon.allWeaponData[itemIndex[i]].weaponName;
        }
    }
    void IfMoreTrinkets(int i, int weaponCount, int trinketCount)
    {
        if (GetRandomIntInRange(trinketCount) >= weaponCount)
        {
            itemIndex[i] = GetRandomIntInRange(weaponCount);
            for (int j = 0; j <= i; j++)
            {
                if (slotContent[j] == weapon.allWeaponData[itemIndex[i]].weaponPrefab)
                {
                    itemIndex[i] = GetRandomIntInRange(weaponCount);
                    j--;
                }
            }
            slotContent[i] = weapon.allWeaponData[itemIndex[i]].weaponPrefab.GetComponent<SpriteRenderer>().sprite;
            textSlots[i].text = weapon.allWeaponData[itemIndex[i]].weaponName;
        }
        else
        {
            itemIndex[i] = GetRandomIntInRange(trinketCount);
            for (int j = 0; j <= i; j++)
            {
                if (slotContent[j] == trinket.allTrinketData[itemIndex[i]].trinketPrefab)
                {
                    itemIndex[i] = GetRandomIntInRange(trinketCount);
                    j--;
                }
            }
            slotContent[i] = trinket.allTrinketData[itemIndex[i]].trinketPrefab.GetComponent<SpriteRenderer>().sprite;
            textSlots[i].text = trinket.allTrinketData[itemIndex[i]].trinketName;
        }
    }
    public void SelectionHandler(Button button)
    {
        string index = button.name;
        selectedField = int.Parse(index);
    }
    public void ConfirmSelections()
    {
        if (itemIndex[selectedField] < weapon.allWeaponData.Count &&
            slotContent[selectedField] == weapon.allWeaponData[itemIndex[selectedField]].weaponPrefab)
        {
            //inventory.AddItem(weapon.allWeaponData[itemIndex[selectedField]].weaponPrefab.GetComponent<SpriteRenderer>().sprite, true);
        }
        else if (itemIndex[selectedField] < trinket.allTrinketData.Count &&
                 slotContent[selectedField] == trinket.allTrinketData[itemIndex[selectedField]].trinketPrefab)
        {
            //inventory.AddItem(trinket.allTrinketData[itemIndex[selectedField]].trinketPrefab.GetComponent<SpriteRenderer>().sprite, false);
        }
        shop.SetActive(false);
    }

    int GetRandomIntInRange(int to)
    {
        return UnityEngine.Random.Range(0, to);
    }

}
