using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_PauseMenu : MonoBehaviour
{

    public void Retry()
    {
        Time.timeScale = 1;
        var s = SceneManager.GetActiveScene();
        SceneManager.LoadScene(s.name);
    }

    public void Resume()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

    public void Quit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
