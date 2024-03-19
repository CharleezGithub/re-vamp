using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class ZShop : MonoBehaviour
{
    public static ZShop Instance;

    public static event Action<ZShopItem> OnItemBought;

    public GameObject ShopUIObject;
    public GameObject[] ShopButtons;

    public DataCollection allShopItemsCollection;

    private List<ZShopItem> items = new List<ZShopItem>();

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

        allShopItemsCollection.trinkets.ForEach((item) => items.Add(new ZShopItem() { TrinketOrWeapon = item, SharedProperties = item}));
        allShopItemsCollection.weapons.ForEach((item) => items.Add(new ZShopItem() { TrinketOrWeapon = item, SharedProperties = item }));
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
            SetShopState();
        }
    }

    public void SetShopState(ShopState state = ShopState.Toggle)
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
        List<ZShopItem> notBoughtItems = items.Where(x => !x.HasBought).ToList();
        for (int i = 0; i < math.min(ShopButtons.Length, notBoughtItems.Count); i++)
        {
            // Get random item and remove from list
            ZShopItem randomItem = notBoughtItems[UnityEngine.Random.Range(0, notBoughtItems.Count)];
            notBoughtItems.Remove(randomItem); // only show once

            // Get sprite and image renderer
            Sprite buttonSprite = randomItem.SharedProperties.GetSprite();
            Image imageRenderer = ShopButtons[i].transform.GetChild(0).GetComponent<Image>();

            // Replace the sprite in the renderer
            imageRenderer.sprite = buttonSprite;
        }
    }
}

public struct ZShopItem
{
    public bool HasBought;
    public ScriptableObject TrinketOrWeapon;
    public IZShopItem SharedProperties;
}

public interface IZShopItem
{
    public Sprite GetSprite();
}

public enum ShopState
{
    Active,
    Inactive,
    Toggle
}