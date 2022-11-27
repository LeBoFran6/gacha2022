using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balance : MonoBehaviour
{
    [SerializeField] private float treshold = 45f;  
    [SerializeField] private float zRot;
    [SerializeField] private UI_GyroIndicator gyroIndicator;

    public Vector2 varianceRange = new Vector2(5, 10);

    private float turbulance = 0;
    private float turbulanceTarget = 0;

    public float turbulanceTargetLerpSpeed = 0.005f;
    public float turbulanceLerpSpeed = 0.1f;

    public void AddTrouble()
    {
        float add = Random.Range(varianceRange.x, varianceRange.y);
        add *= (Random.Range(0, 2) % 2 == 0) ? -1f : 1f;
        turbulanceTarget += add;
    }

    public void AddTrouble(int add)
    {
        turbulanceTarget += add;
    }

    void Update()
    {
        turbulanceTarget = Mathf.Lerp(turbulanceTarget, 0, turbulanceTargetLerpSpeed);
        turbulance = Mathf.Lerp(turbulance, turbulanceTarget, turbulanceLerpSpeed);

        gyroIndicator.UpdateViewSafe(turbulance);

        zRot = transform.eulerAngles.z;

        if(zRot < 180f && zRot > treshold / 2f)
        {
            gyroIndicator.ShowDangerRight(false);
            gyroIndicator.ShowDangerLeft(true);
        }
        else if(zRot > 180f && zRot < (360f - treshold / 2f))
        {
            gyroIndicator.ShowDangerLeft(false);
            gyroIndicator.ShowDangerRight(true);
        }
        else
        {
            gyroIndicator.ShowDangerRight(false);
            gyroIndicator.ShowDangerLeft(false);
        }

        if (zRot < 180f && zRot > treshold)
        {
            GameManager.Instance.deathEvent();
            //Debug.Log("Left Death");
        }
        else if (zRot > 180f && zRot < (360f - treshold))
        {
            GameManager.Instance.deathEvent();
            //Debug.Log("Right Death");
        }
    }
}