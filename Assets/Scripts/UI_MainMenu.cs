using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_MainMenu : MonoBehaviour
{
    public void StartGameLevel(int i)
    {
        LevelData levelData = AppController.Instance.FindLevelByIndex(i);
        AppController.Instance.currentLevel = levelData;

        if(levelData.unlockedDefault)
            UnityEngine.SceneManagement.SceneManager.LoadScene("Tuto");
        else
            UnityEngine.SceneManagement.SceneManager.LoadScene(levelData.levelName);
    }

    public void LoadShop()
    {
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("Shop", UnityEngine.SceneManagement.LoadSceneMode.Additive);
    }

    public void LoadScene(string s)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(s);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
