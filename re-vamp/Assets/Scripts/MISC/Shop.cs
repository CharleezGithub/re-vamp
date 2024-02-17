using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public TextMeshProUGUI[] textSlots;
    public Image[] slotContent;
    public GameObject[] slots;

    public Weapon weapon;
    public Trinket trinket;

    public bool fourthSlotActivated;
    public GameObject shop;
    void Awake()
    {
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
        int slotCount = fourthSlotActivated ? 2 : 1;
        LoadSpritesAndText(slotCount, weapon.allWeaponData.Count, trinket.allTrinketData.Count);
    }
    void LoadSpritesAndText(int slotCount, int weaponCount, int trinketCount)
    {
        slotContent[0].sprite = weapon.allWeaponData[GetRandomIntInRange(weaponCount)].weaponPrefab.GetComponent<SpriteRenderer>().sprite;
        textSlots[0].text = weapon.allWeaponData[GetRandomIntInRange(weaponCount)].name;
        for (int i = 0; i <= slotCount; i++)
        {
            int x = GetRandomIntInRange(trinketCount);
            if (x > weaponCount)
            {
                slotContent[i + 1].sprite = weapon.allWeaponData[GetRandomIntInRange(weaponCount)].weaponPrefab.GetComponent<SpriteRenderer>().sprite;
                textSlots[i + 1].text = weapon.allWeaponData[GetRandomIntInRange(weaponCount)].name;
            }
            else
            {
                slotContent[i + 1].sprite = trinket.allTrinketData[GetRandomIntInRange(trinketCount)].trinketPrefab.GetComponent<SpriteRenderer>().sprite;
                textSlots[i + 1].text = trinket.allTrinketData[GetRandomIntInRange(trinketCount)].name;
            }
        }
    }
    public void ConfirmSelections()
    {
        shop.SetActive(false);
    }
    int GetRandomIntInRange(int to)
    {
        return Random.Range(0, to);
    }
}
