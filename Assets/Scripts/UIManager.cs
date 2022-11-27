using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI UIGyro;
    [SerializeField] private GameObject UIDangerRight;
    [SerializeField] private GameObject UIDangerLeft;
    private float gyroX;

    void Update()
    {
        UIGyro.SetText("" + gyroX);
    }

    public void getGyroX(float _gyroX)
    {
        gyroX = _gyroX;
    }

    public void showDangerRight()
    {
        UIDangerRight.SetActive(true);
    }

    public void showDangerLeft()
    {
        UIDangerLeft.SetActive(true);
    }

    public void hideDangerRight()
    {
        UIDangerRight.SetActive(false);
    }

    public void hideDangerLeft()
    {
        UIDangerLeft.SetActive(false);
    }
}
