using UnityEngine;
using UnityEngine.SceneManagement;

public class Backfromsettings : MonoBehaviour
{
    // Angiv navnet p� den scene, du vil skifte til
    public string Start;

    // Metode kaldt, n�r knappen bliver trykket
    public void OnButtonPress()
    {
        // Skift scene til den angivne scene
        SceneManager.LoadScene(Start);
    }
}
    


