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

    private void Awake()
    {
        PlayerPrefs.DeleteAll();
        DontDestroyOnLoad(gameObject);
        CosmeticHolder.Instance.LoadGame();
        Money = 100;
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneToLoad);
    }

    private void OnApplicationQuit()
    {
        CosmeticHolder.Instance.SaveGame();
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
