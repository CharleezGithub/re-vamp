using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class fpscode : MonoBehaviour {

    public float fps;
    public TextMeshProUGUI fpsText;

    private void Start()
    {
        InvokeRepeating("GetFPS", 1, 1);

    }
    public void GetFPS()

    {
        fps = (int)(1f / Time.unscaledDeltaTime) ;
        fpsText.text = fps + "fps";
    }

}