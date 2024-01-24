using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    // Angiv navnet p� den scene, du vil skifte til
    public string Scene2;

    // Metode kaldt, n�r knappen bliver trykket
    public void OnButtonPress()
    {
        // Skift scene til den angivne scene
        SceneManager.LoadScene(Scene2);
    }
}
