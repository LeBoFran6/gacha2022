using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    public GameObject herbe;
    //public GameObject player;
    public float speed;
    public int feuille = 0;


    // Update is called once per frame
    void Update()
    {
        herbe.transform.position = transform.position + new Vector3(0, 0, -1 * speed * Time.deltaTime);
    }
}
