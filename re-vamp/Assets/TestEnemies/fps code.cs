using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fpscode : MonoBehaviour {

    public float fps;
    public Text fpsText;

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