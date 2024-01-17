using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    public Image XPBar;
    public TextMeshProUGUI levelText;
    public float limit;
    private float scaleSpeed = 0.001f;
    private float transformSpeed = 0.15f;
    private Vector2 XPBarStartScale;
    private Vector2 XPBarStartPosition;
    private int currentLevel;
    void Start()
    {
        StartVariables();
    }

    void Update()
    {
        VariableUpdate();
    }

    void StartVariables()
    {
        if (XPBar != null)
        {
            XPBarStartScale = XPBar.transform.localScale;
            XPBarStartPosition = XPBar.transform.localPosition;
        }
    }
    void VariableUpdate()
    {
        if (XPBar != null && XPBar.transform.localScale.x >= limit)
        {
            UpdateText();
            XPBar.transform.localScale = XPBarStartScale;
            XPBar.transform.localPosition = XPBarStartPosition;
        }
    }
    void UpdateText()
    {
        currentLevel = currentLevel + 1;
        string level = "Level: " + currentLevel;
        levelText.text = level;
    }
    public void AddXP(int XP)
    {
        if (XP > 0 && XPBar.transform.localScale.x < limit)
        {
            Debug.Log(XP);
            scaleSpeed = 0.01f - currentLevel / 10;
            transformSpeed = 1.5f - currentLevel / 10;
            XPBar.transform.localScale = new Vector2(XPBar.transform.localScale.x + scaleSpeed, XPBar.transform.localScale.y);
            XPBar.transform.localPosition = new Vector2(XPBar.transform.localPosition.x + transformSpeed, XPBar.transform.localPosition.y);
            scaleSpeed = 0f;
            transformSpeed = 0f;
        }
    }
}
