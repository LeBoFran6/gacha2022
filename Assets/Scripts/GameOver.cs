using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class GameOver : MonoBehaviour
{

    public GameManager script;

    private void OnTriggerEnter(Collider other)
    {
        compte_herbe addPlante = other.GetComponent<compte_herbe>();
        if (addPlante == null)
        {
            script.deathEvent();
        }

    }
}
