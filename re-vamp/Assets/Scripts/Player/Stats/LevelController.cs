using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    public float xp;
    public float maxXP;
    public int level;
    [SerializeField] private Shop shop;
    private void Start()
    {
        if (level == 0)
            maxXP = 100;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X)) // TODO : remove this
            GiveXP(maxXP);
    }
    public void GiveXP(float xpGain)
    {
        xp += xpGain;
        if (xp >= maxXP)
        {
            StartCoroutine(LevelUp());
        }
    }
    IEnumerator LevelUp()
    {
        while (xp >= maxXP)
        {
            if (Time.timeScale != 0)
            {
                float extraXP = xp - maxXP;
                level++;
                ShowShop();// Show shop when leveling up
                maxXP = (float)Math.Round(maxXP + maxXP * 0.2f);
                xp = extraXP;
                yield return null;
            }
            else
                yield return null;
        }
    }
    void ShowShop()
    {
        if (shop != null)
        {
            shop.gameObject.SetActive(true);
            shop.ShowShop(true);
        }
    }
}
