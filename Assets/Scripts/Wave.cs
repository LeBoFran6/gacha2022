using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Balance b = other.GetComponent<Balance>();
        if (b != null)
            b.AddTrouble();
    }
}
