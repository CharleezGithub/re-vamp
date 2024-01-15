using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPController : MonoBehaviour
{
    public GameObject XPBar;
    public float XPBarXPosition;
    public float XPBarXSize;
    // Start is called before the first frame update
    void Start()
    {
        StartVariables();
    }

    // Update is called once per frame
    void Update()
    {
        VariableUpdate();
        XPBarXSize = XPBarXSize + 0.01f;        
    }

    void StartVariables()
    {
        XPBarXPosition = XPBar.transform.position.x;
        XPBarXSize = XPBar.transform.localScale.x;
    }
    void VariableUpdate()
    {
        XPBar.transform.localScale = new Vector3(XPBarXSize,0f,0f);
        XPBar.transform.localPosition = new Vector3(XPBarXPosition, 0f,0f);
    }
}
