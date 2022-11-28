using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class GameOver : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        Wave w = other.transform.GetComponent<Wave>();
        Ending ending = other.GetComponent<Ending>();
        compte_herbe addPlante = other.GetComponent<compte_herbe>();
        if (addPlante == null && ending == null && w == null)
        {
            GameManager.Instance.deathEvent();
        }
    }
}
