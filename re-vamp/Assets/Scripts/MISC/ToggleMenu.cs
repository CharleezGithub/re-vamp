using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleMenu : MonoBehaviour
{
    public GameObject panelMenu;

    bool tog;

    void Start()
    {
        panelMenu.SetActive(false);
        tog = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Toggle_Menu();
        }


        if (!tog)
            Time.timeScale = 1.0f;
        else if (tog)
            Time.timeScale = 0;
    }

    public void Toggle_Menu()
    {
        tog = !tog;

        panelMenu.SetActive(tog);
    }

}
