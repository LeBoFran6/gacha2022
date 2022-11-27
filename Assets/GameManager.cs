using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject player;

    public UI_GameOver gameoverScreen;
    private bool isAlive;

    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive)
        {
            player.SetActive(false);
        }
    }

    public void WinEvent()
    {
        gameoverScreen.ShowWinScreen(0, 0, 0);
    }

    public void deathEvent()
    {
        isAlive = false;
        gameoverScreen.ShowLoseScreen();
    }
}
