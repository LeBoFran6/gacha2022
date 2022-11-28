using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DopplerActivate : MonoBehaviour
{
    public int doppler;


    void Update()
    {
        RaycastHit hit;
        Physics.Raycast(transform.forward, transform.position, out hit);
        ObstacleObject obj = hit.collider.GetComponent<ObstacleObject>();
        Debug.LogError(obj);
        if (obj != null)
        {
            Debug.LogError(obj);
            obj.PlaySoundOn(doppler);
        }
    }
}
