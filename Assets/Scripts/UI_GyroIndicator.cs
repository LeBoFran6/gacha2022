using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_GyroIndicator : MonoBehaviour
{
    public Transform pivot;
    public Transform pivotSafeZone;
    public GameObject dangerLeft;
    public GameObject dangerRight;

    private float zPivot = 0;
    private float zPivotTarget = 0;

    public void Update()
    {
        zPivot = Mathf.Lerp(zPivot, zPivotTarget, 0.1f);
        pivot.rotation = Quaternion.Euler(new Vector3(0,0, zPivot));
    }

    public void UpdateView(float f)
    {
        zPivotTarget = f;
    }

    public void UpdateViewSafe(float f)
    {
        pivotSafeZone.rotation = Quaternion.Euler(new Vector3(0, 0, f));
    }

    public void ShowDangerLeft(bool b)
    {
        dangerLeft.SetActive(b);
    }

    public void ShowDangerRight(bool b)
    {
        dangerRight.SetActive(b);
    }
}
