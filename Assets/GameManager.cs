using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.ConstrainedExecution;
using UnityEngine.Experimental.Rendering.Universal;
public class GameManager : MonoBehaviour
{
    static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<GameManager>();
            return _instance;
        }
    }

    [SerializeField] private GameObject player;
    public TMP_Text herbes;
    public TMP_Text score;
    [SerializeField] private GameObject gameOverTextObject;
    [SerializeField] private RenderObjects URPRenderObjects;
    [SerializeField] private uint herbTreshold;
    [SerializeField] private uint globalHerbs;
    [SerializeField] private uint currentHerbs;
    public UI_GameOver gameoverScreen;
    public UI_PauseMenu pauseMenu;
    private bool isAlive;

    public int herbe = 0;

    public void AddHerbe()
    {
        herbe++;
        UpdateHerbe(herbe);
    }

    public void LostHerbe()
    {
        herbe--;
        UpdateHerbe(herbe);
    }

    public void Pause()
    {
        Time.timeScale = 0;
        pauseMenu.gameObject.SetActive(true);
    }

    void Start()
    {
        isAlive = true;
    }

    public void UpdateScore(int s)
    {
        score.text = s.ToString();
    }

    public void UpdateHerbe(int herbe)
    {
        herbes.text = herbe.ToString();
    }

    void Update()
    {
        if (!isAlive)
        {
gameOverTextObject.SetActive(true);            
player.SetActive(false);
        }

        if(currentHerbs == herbTreshold)
        {
            currentHerbs = 0;
            URPRenderObjects.SetActive(true);
            StartCoroutine(PsychoMode());
        }
    }

    public void WinEvent()
    {
        LevelData data = AppController.Instance.currentLevel;
        gameoverScreen.ShowWinScreen(0, 0, 0);
    }

    public void deathEvent()
    {
        isAlive = false;
        gameoverScreen.ShowLoseScreen();
    }

    public void collectHerb()
    {
        globalHerbs++;
        currentHerbs++;
    }

    IEnumerator PsychoMode()
    {
        yield return new WaitForSeconds(3f);

        URPRenderObjects.SetActive(false);
    }
}
