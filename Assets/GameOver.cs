using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        compte_herbe addPlante = other.GetComponent<compte_herbe>();
        if (addPlante == null)
        {
            gameManager.deathEvent();
        }

    }
}
