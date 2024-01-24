using UnityEngine;
using UnityEngine.SceneManagement;

public class Backfromsettings : MonoBehaviour
{
    // Angiv navnet på den scene, du vil skifte til
    public string Start;

    // Metode kaldt, når knappen bliver trykket
    public void OnButtonPress()
    {
        // Skift scene til den angivne scene
        SceneManager.LoadScene(Start);
    }
}
    


