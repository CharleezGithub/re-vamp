using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class Backfromsettings : MonoBehaviour
{
    // Angiv navnet på den scene, du vil skifte til
    public string start;

    // Metode kaldt, når knappen bliver trykket
    public void OnButtonPress()
    {
        if (start != null)
        {
        // Skift scene til den angivne scene
        SceneManager.LoadScene(start);
        }
    }
}
    


