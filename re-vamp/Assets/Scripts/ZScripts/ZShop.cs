using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class ZShop : MonoBehaviour
{
    public static ZShop Instance;

    public static event Action<ZShopItem> OnItemBought;

    public static ZShopItem[] ItemsBought => Instance.items.Where(x => x.HasBought).ToArray();
    public static ZShopItem[] NotItemsBought => Instance.items.Where(x => !x.HasBought).ToArray();

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

        items = allShopItemsCollection.trinkets.Cast<IZShopItem>().Concat(allShopItemsCollection.weapons.Cast<IZShopItem>()).Select(x=>new ZShopItem() { TrinketOrWeapon = (ScriptableObject)x, SharedProperties = x}).ToArray();
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

    private void OnBuyTestMethod(ZShopItem obj)
    {
        // Kim. Look at here
        print($"Bought: " + obj.SharedProperties.GetName());
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

        List<ZShopItem> notBoughtItems = items.Where(x => !x.HasBought).ToList();
        for (int i = 0; i < math.min(ShopButtons.Length, notBoughtItems.Count); i++)
        {
            // Getting close to pyramid of doom. This should not be an if statement
            if (notBoughtItems.Count > 0)
            {
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
                // Get sprite and image renderer
                Image imageRenderer = ShopButtons[i].transform.GetChild(0).GetComponent<Image>();

                // Replace the sprite in the renderer
                imageRenderer.sprite = null;
            }
        }
    }

    public void BuyItem(int buttonIndex)
    {
        if (buttonIndex > showingItemIds.Count) return; // Stops if button clicked is out of range

        // Grab item from array
        int itemIndex = showingItemIds[buttonIndex];
        ZShopItem boughtItem = items[itemIndex];

        boughtItem.HasBought = true; // Buy the item (Disgusting code but it works)
        SetShopState(ShopState.Inactive);

        OnItemBought?.Invoke(boughtItem);
        items[showingItemIds[buttonIndex]] = boughtItem; // Re-inject back to array
    }
}

public struct ZShopItem
{
    public int id;
    public string name;
    public bool HasBought;
    public ScriptableObject TrinketOrWeapon;
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