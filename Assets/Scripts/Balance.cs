using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balance : MonoBehaviour
{
    [SerializeField] private float treshold = 45f;
    [SerializeField] private float zRot;
    [SerializeField] private GameManager _GameManager;
    [SerializeField] private UIManager _UIManager;
    public GameObject JeanPoilIsFalling;

    void Update()
    {
        zRot = transform.eulerAngles.z;

        if(zRot < 180f && zRot > treshold / 2f)
        {
            _UIManager.hideDangerRight();
            _UIManager.showDangerLeft();
            JeanPoilIsFalling.SetActive(true);

        }
        else if(zRot > 180f && zRot < (360f - treshold / 2f))
        {
            _UIManager.hideDangerLeft();
            _UIManager.showDangerRight();
            JeanPoilIsFalling.SetActive(true);
        }
        else
        {
            _UIManager.hideDangerRight();
            _UIManager.hideDangerLeft();
            JeanPoilIsFalling.SetActive(false);
        }

        if (zRot < 180f && zRot > treshold)
        {
            _GameManager.deathEvent();
            //Debug.Log("Left Death");
        }
        else if (zRot > 180f && zRot < (360f - treshold))
        {
            _GameManager.deathEvent();
            //Debug.Log("Right Death");
        }
    }
}