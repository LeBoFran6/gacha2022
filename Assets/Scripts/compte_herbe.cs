using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class compte_herbe : MonoBehaviour
{
    public GameObject deletePref;

    public void OnPlayerTriggerEnter(GameObject Player)
    {
        Destroy(gameObject);
        Instantiate(deletePref, transform.position, transform.rotation);

    }
}
