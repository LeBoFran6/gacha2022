using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_MainMenu : MonoBehaviour
{
    public void LoadScene(string s)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(s);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
