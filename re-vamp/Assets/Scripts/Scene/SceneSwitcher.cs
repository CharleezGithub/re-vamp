using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    // Angiv navnet på den scene, du vil skifte til
    public string Scene2;

    // Metode kaldt, når knappen bliver trykket
    public void OnButtonPress()
    {
        // Skift scene til den angivne scene
        SceneManager.LoadScene(Scene2);
    }
}
