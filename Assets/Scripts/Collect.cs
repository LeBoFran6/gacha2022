using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{

    private void OnTriggerEnter(Collider plante)
    {
        compte_herbe addPlante = plante.GetComponent<compte_herbe>();
        if(addPlante != null)
        {
            GameManager.Instance.AddHerbe();
            addPlante.OnPlayerTriggerEnter(gameObject);
        }
    }

}
