using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    public GameObject plante;
    public GameObject obst;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider plante)
    {
        compte_herbe addPlante = plante.GetComponent<compte_herbe>();
        if(addPlante != null)
        {
            GameController.Instance.AddHerbe();
            addPlante.OnPlayerTriggerEnter(gameObject);
        }
    }

}
