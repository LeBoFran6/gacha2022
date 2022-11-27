using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfter : MonoBehaviour
{
    public float tps;
    
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, tps);
    }

    
}
