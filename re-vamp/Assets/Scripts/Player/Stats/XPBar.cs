using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class XPBar : MonoBehaviour
{
    public TextMeshProUGUI xpText;
    public TextMeshProUGUI levelText;

    public Slider xpBar;

    private LevelController levelController;
    private void Awake()
    {
        levelController = gameObject.transform.parent.parent.GetComponent<LevelController>();

        if (levelController == null)
        {
            Debug.LogError("LevelController component not found in the parent of the parent GameObject.");
        }
    }
    private void Update()
    {
        float roundedXP = (float)Math.Round(levelController.xp, 1);
        xpText.text = "" + roundedXP + " / " + levelController.maxXP;

        levelText.text = "" + levelController.level;

        xpBar.maxValue = levelController.maxXP;
        xpBar.value = levelController.xp;
    }
}
