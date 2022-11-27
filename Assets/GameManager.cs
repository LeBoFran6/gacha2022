using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject gameOverTextObject;

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
            gameOverTextObject.SetActive(true);
            player.SetActive(false);
        }
    }

    public void deathEvent()
    {
        isAlive = false;
    }
}
