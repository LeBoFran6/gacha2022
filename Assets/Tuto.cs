using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tuto : MonoBehaviour
{
    public void LoadScene()
    {
        SceneManager.LoadScene(AppController.Instance.currentLevel.levelName);
    }
}
