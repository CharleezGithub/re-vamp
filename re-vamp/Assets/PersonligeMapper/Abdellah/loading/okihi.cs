using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class okihi : MonoBehaviour
{
    public GameObject lalala;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider.value = 0;
    }

    // Update is called once per frame
 void Update()
{
    if (slider.value < slider.maxValue)
    {
            slider.value++;
    }
    else if (slider.value == slider.maxValue)
    {
        
        Destroy(lalala);
    }
}

}
