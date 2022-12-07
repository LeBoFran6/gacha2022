using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.ConstrainedExecution;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.Rendering.Universal;

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
    [SerializeField] private RenderObjects URPRenderObjects;
    [SerializeField] private Material psycho;
    [SerializeField] private uint herbTreshold;
    [SerializeField] private uint globalHerbs;
    [SerializeField] private uint currentHerbs;
    public UI_GameOver gameoverScreen;
    public UI_PauseMenu pauseMenu;

    public float iframeBegining = 3f;
    public float timeBetweenWaves = 5f;
    private bool isAlive;

    public void OnDestroy()
    {
        URPRenderObjects.SetActive(false);
    }

    public int herbe = 0;

    public void AddHerbe()
    {
        herbe++;
        globalHerbs++;
        currentHerbs++;
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
            player.SetActive(false);
        }

        if(currentHerbs == herbTreshold)
        {
            currentHerbs = 0;
            URPRenderObjects.SetActive(true);
            StartCoroutine(PsychoMode());
        }
    }

    public bool finishedGame = false;

    public void WinEvent()
    {
        LevelData data = AppController.Instance.currentLevel;
        gameoverScreen.ShowWinScreen(0, 0, 0);
        finishedGame = true;
    }

    public void deathEvent()
    {
        if (!GameManager.Instance.finishedGame)
        { 
            isAlive = false;
            gameoverScreen.ShowLoseScreen();
        }
    }

    IEnumerator QuickChromaEffect()
    {
        yield return null;
        //      PostProcessVolume m_Volume;
        //      Vignette m_Vignette
        // void Start()
        //      {
        //          // Create an instance of a vignette
        //          m_Vignette = ScriptableObject.CreateInstance<Vignette>();
        //          m_Vignette.enabled.Override(true);
        //          m_Vignette.intensity.Override(1f);
        //          // Use the QuickVolume method to create a volume with a priority of 100, and assign the vignette to this volume
        //          m_Volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, m_Vignette);
        //          void Update()
        //          {
        //              // Change vignette intensity using a sinus curve
        //              m_Vignette.intensity.value = Mathf.Sin(Time.realtimeSinceStartup);
        //          }
        //          void OnDestroy()
        //          {
        //              RuntimeUtilities.DestroyVolume(m_Volume, true, true);
        //          }
    }

    IEnumerator LerpPsychoIn()
    {
        float f = 0;
        int i = 0;
        while (i < 60)
        {
            psycho.SetFloat("_hallu", Mathf.Lerp(f, 1f, 0.05f));
            i++;
            yield return null;
        }
        psycho.SetFloat("_hallu", 1f);
    }

    IEnumerator LerpPsychoOut()
    {

        float f = 0;
        int i = 0;
        while (i < 60)
        {
            psycho.SetFloat("_hallu", Mathf.Lerp(f, 1f, 0.05f));
            i++;
            yield return null;
        }
        psycho.SetFloat("_hallu", 1f);
    }

    IEnumerator PsychoMode()
    {
        LerpPsychoIn();

        yield return new WaitForSeconds(3f);

        URPRenderObjects.SetActive(false);

        LerpPsychoOut();
    }
}
