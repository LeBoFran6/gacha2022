using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject Player;
    public GameObject gameOver;
    public Collect script;

    private void OnTriggerEnter(Collider other)
    {
        compte_herbe addPlante = other.GetComponent<compte_herbe>();
        if (addPlante == null)
        {
            gameOver.SetActive(true);
            Player.SetActive(false);
        }

    }
}
