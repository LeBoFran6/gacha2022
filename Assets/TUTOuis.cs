using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TUTOuis : MonoBehaviour
{
    public GameObject L;
    public GameObject BL;
    public GameObject D;
    public GameObject BD;



    public void Left()
    {
        L.SetActive(false);
        BL.SetActive(false);
        D.SetActive(true);
        BD.SetActive(true);
    }

    public void Right()
    {
        D.SetActive(false);
        BD.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
