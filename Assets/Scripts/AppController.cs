using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppController : MonoBehaviour
{
    private static AppController _instance;
    public static AppController Instance
    {
        get 
        { 
            if (_instance == null)
                _instance = FindObjectOfType<AppController>();
            
            return _instance; 
        }
    }

    [SerializeField]
    private string sceneToLoad = "none";

    [SerializeField]
    private bool resetDB = false;

    [SerializeField]
    private LevelData[] levels;
    public LevelData currentLevel;

    public LevelData FindLevelByName(string name)
    {
        for (int i = 0; i < levels.Length; i++)
        {
            if (levels[i].levelName == name)
                return levels[i];
        }

        return null;
    }

    private void Awake()
    {
        if(resetDB)
            PlayerPrefs.DeleteAll();
        DontDestroyOnLoad(gameObject);
        CosmeticHolder.Instance.LoadGame();
        LoadGame();
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneToLoad);
    }

    public void SaveGame()
    {
        for (int i = 0; i < levels.Length; i++)
        {
            levels[i].SaveLevelProgress();
        }
    }

    public void LoadGame()
    {
        for (int i = 0; i < levels.Length; i++)
        {
            levels[i].LoadLevelProgress();
        }
    }

    private void OnApplicationQuit()
    {
        CosmeticHolder.Instance.SaveGame();
        SaveGame();
    }

    public int Money
    {
        get
        {
            return PlayerPrefs.GetInt("Money", 0);
        }
        set
        {
            PlayerPrefs.SetInt("Money", value);
        }
    }

    public void BuyItem(CosmeticItem item)
    {
        Money -= item.price;
    }
}


public class LevelData 
{
    public string levelName;
    public string nextLevel;
    public int diffiuclty;
    [SerializeField]
    private bool unlocked;
    [SerializeField]
    private bool success;
    [SerializeField]
    private int stars;
    [SerializeField]
    private bool unlockedDefault;

    public bool Success
    {
        get
        {
            success = PlayerPrefs.GetInt("SuccessLevel_" + levelName, 0) == 1;
            return success;
        }
        set
        {
            success = value;
            PlayerPrefs.SetInt("SuccessLevel_" + levelName, success ? 1 : 0);
        }
    }
    public int Stars
    {
        get
        {
            stars = PlayerPrefs.GetInt("StarsLevel_" + levelName, 0);
            return stars;
        }
        set
        {
            stars = value;
            PlayerPrefs.SetInt("StarsLevel_" + levelName, stars);
        }
    }
    public bool Unlocked
    {
        get
        {
            unlocked = PlayerPrefs.GetInt("UnlockedLevel_" + levelName, 0) == 1;
            return unlocked;
        }
        set
        {
            unlocked = value;
            PlayerPrefs.SetInt("UnlockedLevel_" + levelName, unlocked ? 1 : 0);
        }
    }

    public void SaveLevelProgress()
    {
        PlayerPrefs.SetInt("UnlockedLevel_" + levelName, unlocked ? 1 : 0);
        PlayerPrefs.SetInt("SuccessLevel_" + levelName, success ? 1 : 0);
        PlayerPrefs.SetInt("StarsLevel_" + levelName, stars);
    }

    public void LoadLevelProgress()
    {
        if(!unlockedDefault)
            unlocked =  PlayerPrefs.GetInt("UnlockedLevel_" + levelName, 0) == 1;
        success = PlayerPrefs.GetInt("SuccessLevel_" + levelName, 0) == 1;
        stars = PlayerPrefs.GetInt("StarsLevel_" + levelName, 0);
    }
}