using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class ZShop : MonoBehaviour
{
    public static ZShop Instance;

    public static event Action<ZShopItem> OnItemBought;

    public static ZShopItem[] ItemsBought => Instance.items.Where(x => x.boughtTimes > 0).ToArray();
    public static ZShopItem[] NotItemsBought => Instance.items.Where(x => x.boughtTimes == 0).ToArray();

    public GameObject ShopUIObject;
    public GameObject[] ShopButtons;

    public DataCollection allShopItemsCollection;

    private ZShopItem[] items;
    private List<int> showingItemIds = new List<int>(); // Used to store the index of which item is being displayed

    private void OnEnable()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
            Instance = this;
        }

        items = allShopItemsCollection.trinkets.Cast<IZShopItem>().Concat(allShopItemsCollection.weapons.Cast<IZShopItem>()).Select(x=>new ZShopItem() { TrinketOrWeapon = (ZItemSO)x, SharedProperties = x}).ToArray();
        for (int i = 0; i < items.Length; i++)
        {
            items[i].id = i;
            items[i].name = items[i].SharedProperties.GetName();
        }

        Debug.Log("[Shop] Loaded: " + items.Select(x=>x.name).Aggregate((x, y) => x + ", " + y));

        // Init buttons
        for (int i = 0; i < ShopButtons.Length; i++)
        {
            int buttonIndexCapture = i;

            Button btn = ShopButtons[i].GetComponent<Button>();
            btn.onClick.AddListener(() => BuyItem(buttonIndexCapture));
        }

        OnItemBought += OnBuyTestMethod;
    }

    private void OnBuyTestMethod(ZShopItem boughtItem)
    {
        // Kim. Look at here
        print("Bought: " + boughtItem.SharedProperties.GetName() 
            + "\nItemType: " + boughtItem.SharedProperties.GetItemType()
            + "\nItem bought times: " + boughtItem.level); // Also works with: boughtItem.boughtTimes

        print($"Item count of level 2 or over: {ItemsBought.Where(x=>x.boughtTimes > 2).Count()}");
    }

    private void Awake()
    {
        ShopUIObject.SetActive(false);
    }

    private void Update()
    {
        // TODO: remove this (use only for debugging)
        if (Input.GetKeyDown(KeyCode.F))
        {
            SetShopState(ShopState.Toggle);
        }
    }

    public void SetShopState(ShopState state)
    {
        switch (state)
        {
            case ShopState.Active:
                ShopUIObject.SetActive(true);
                break;
            case ShopState.Inactive:
                ShopUIObject.SetActive(false);
                break;
            case ShopState.Toggle:
                ShopUIObject.SetActive(!ShopUIObject.activeSelf); // Toggles shop
                break;
        }

        RefreshShop();
    }

    public void RefreshShop()
    {
        showingItemIds.Clear();

        // Clears the button icons
        for (int i = 0; i < ShopButtons.Length; i++)
        {
            // Get sprite and image renderer
            Image imageRenderer = ShopButtons[i].transform.GetChild(0).GetComponent<Image>();

            // Replace the sprite in the renderer
            imageRenderer.sprite = null;
        }

        List<ZShopItem> notBoughtItems = items.Where(x => x.boughtTimes < x.maxBuyTimes).ToList();
        for (int i = 0; i < ShopButtons.Length; i++)
        {
            // Getting close to pyramid of doom. This should not be an if statement
            if (notBoughtItems.Count > 0)
            {
                ShopButtons[i].SetActive(true);

                // Get random item and remove from list
                int randomIndex = UnityEngine.Random.Range(0, notBoughtItems.Count);
                ZShopItem randomItem = notBoughtItems[randomIndex];
                notBoughtItems.Remove(randomItem); // only show once

                // Get sprite and image renderer
                Sprite buttonSprite = randomItem.SharedProperties.GetSprite();
                Image imageRenderer = ShopButtons[i].transform.GetChild(0).GetComponent<Image>();

                // Replace the sprite in the renderer
                imageRenderer.sprite = buttonSprite;

                // Store this item as showing
                showingItemIds.Add(randomItem.id);
            }
            else
            {
                ShopButtons[i].SetActive(false); // Don't show button if bought too many
            }
        }
    }

    public void BuyItem(int buttonIndex)
    {
        if (buttonIndex > showingItemIds.Count - 1)
        {
            SetShopState(ShopState.Inactive);
            return; // Stops if button clicked is out of range
        }

        // Grab item from array
        int itemIndex = showingItemIds[buttonIndex];
        ZShopItem boughtItem = items[itemIndex];

        boughtItem.boughtTimes++; // Buy the item
        SetShopState(ShopState.Inactive);

        OnItemBought?.Invoke(boughtItem);
    }
}

public class ZShopItem
{
    public int id;
    public string name;
    public uint boughtTimes = 0;
    public uint maxBuyTimes => TrinketOrWeapon.maxBuyTimes;
    public uint level => boughtTimes; // For the haters
    public ZItemSO TrinketOrWeapon;
    public IZShopItem SharedProperties;
}

public interface IZShopItem
{
    public Sprite GetSprite();
    public string GetName();
    public ItemType GetItemType();
}

public enum ItemType
{
    Trinket,
    Weapon
}

public enum ShopState
{
    Active,
    Inactive,
    Toggle
}

public abstract class ZItemSO : ScriptableObject
{
    public uint maxBuyTimes = 1;
    public uint level => maxBuyTimes; // For the haters wanting to say level.
}