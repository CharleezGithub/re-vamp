using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class Backfromsettings : MonoBehaviour
{
    // Angiv navnet p� den scene, du vil skifte til
    public string start;

    // Metode kaldt, n�r knappen bliver trykket
    public void OnButtonPress()
    {
        if (start != null)
        {
        // Skift scene til den angivne scene
        SceneManager.LoadScene(start);
        }
    }
}
    


