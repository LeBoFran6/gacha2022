using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        GameManager.Instance.WinEvent();
    }
}
