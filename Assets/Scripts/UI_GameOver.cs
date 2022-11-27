using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UI_GameOver : MonoBehaviour
{
    public GameObject win;
    public GameObject lose;

    public TMP_Text score;
    public TMP_Text money;

    public GameObject[] completStar;
    public void ShowLoseScreen()
    {
        gameObject.SetActive(true);
        win.SetActive(false);
        lose.SetActive(true);
    }

    public void ShowWinScreen(int score, int money, int stars)
    {
        gameObject.SetActive(true);
        win.SetActive(true);
        lose.SetActive(false);

        this.score.text = score.ToString();
        this.money.text = money.ToString();

        for (int i = 0; i < stars; i++)
        {
            completStar[i].SetActive(true);
        }
    }

    public void Shop() 
    {
        SceneManager.LoadSceneAsync("Shop", LoadSceneMode.Additive);
    }

    public void Next()
    {
        LevelData levelData = AppController.Instance.currentLevel;
        LevelData nextLevel = AppController.Instance.FindLevelByName(levelData.nextLevel);
        SceneManager.LoadScene(nextLevel.levelName);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Retry()
    {
        var s = SceneManager.GetActiveScene();
        SceneManager.LoadScene(s.name);
    }
}
