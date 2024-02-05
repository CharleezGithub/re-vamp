using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{

    // Metode kaldt, når knappen bliver trykket
    public void OnButtonPress()
    {
        // Skift scene til den angivne scene
        SceneManager.LoadScene(this.name);
    }
}
