using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacles : MonoBehaviour
{
    
    public GameObject GO;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        GO.transform.position = transform.position + new Vector3(0,0, -1 * speed * Time.deltaTime);
        
    }
}
