using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class XPBar : LevelController
{
    public TextMeshProUGUI xpText;
    public TextMeshProUGUI levelText;

    public Slider xpBar;
    private void Update()
    {
        float roundedXP = (float)Math.Round(xp, 1);
        xpText.text = "" + roundedXP + " / " + maxXP;

        levelText.text = "" + level;

        xpBar.maxValue = maxXP;
        xpBar.value = xp;
    }
}
