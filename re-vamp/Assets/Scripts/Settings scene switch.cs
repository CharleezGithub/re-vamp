using UnityEngine;
using UnityEngine.SceneManagement;

public class Settingssceneswitch : MonoBehaviour
{
    // Angiv navnet p� den scene, du vil skifte til
    public string Settings;

    // Metode kaldt, n�r knappen bliver trykket
    public void OnButtonPress()
    {
        // Skift scene til den angivne scene
        SceneManager.LoadScene(Settings);
    }
}

