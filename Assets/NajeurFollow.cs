using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NajeurFollow : MonoBehaviour
{
    public GameObject Player;
    public GameObject Pousse;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Pousse.transform.position = new Vector3 (Player.transform.position.x, 3.34f, Pousse.transform.position.z);
    }
}
