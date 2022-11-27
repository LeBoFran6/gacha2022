using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class GameOver : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        Ending ending = other.GetComponent<Ending>();
        compte_herbe addPlante = other.GetComponent<compte_herbe>();
        if (addPlante == null && ending == null)
        {
            GameManager.Instance.deathEvent();
        }
    }
}
