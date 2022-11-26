using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deplacements : MonoBehaviour
{
    public Rigidbody rb;
    bool G = false;
    bool D = false;
    int positionPlayer = 1;
    public void Gauche()
    {
        Debug.Log("G");
        G = true;
    }
    public void Droite()
    {
        Debug.Log("D");
        D = true;
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(positionPlayer != 0)
        {
            if (G)
            {
                rb.velocity = new Vector3(-35, 0, 0);
                positionPlayer--;
                G = false;
            }
        }

        if (positionPlayer != 2)
        {
            if (D)
            {
                rb.velocity = new Vector3(35, 0, 0);
                positionPlayer++;
                D = false;
            }
        }
        D = false;
        G = false;
    }
}
