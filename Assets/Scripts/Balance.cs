using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balance : MonoBehaviour
{
    public GameObject JeanPoilIdle;
    public GameObject JeanPoilIsFalling;


    [SerializeField] private float tresholdMin = 30f;  
    [SerializeField] private float tresholdMax = 45f;
    [SerializeField] private float currentTreshold = 45f;
    [SerializeField] private float zRot;
    [SerializeField] private UI_GyroIndicator gyroIndicator;

    public Vector2 varianceRange = new Vector2(10, 20);

    private float turbulance = 0;
    private float turbulanceTarget = 0;
    public float maxTurbulance = 20;
    [Range(0f, 1f)]
    public float percentageWarning = .5f;

    public float turbulanceTargetLerpSpeed = 0.005f;
    public float turbulanceLerpSpeed = 0.1f;

    bool gameStarting = true;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(GameManager.Instance.iframeBegining);
        gameStarting = false;
        while (true)
        {
            yield return new WaitForSeconds(GameManager.Instance.timeBetweenWaves);
            AddTrouble();
        }
    }

    public void AddTrouble()
    {
        float add = Random.Range(varianceRange.x, varianceRange.y);
        add *= (Random.Range(0, 2) % 2 == 0) ? -1f : 1f;
        turbulanceTarget += add;
        turbulanceTarget = Mathf.Clamp(turbulanceTarget, -maxTurbulance, maxTurbulance);
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

        float v = zRot > 180 ? zRot - 360f : zRot;

        //Debug.LogError(turbulanceTarget);
        //Debug.LogError(currentTreshold + turbulance - warrningTreshold);
        //Debug.LogError(-currentTreshold + turbulance + warrningTreshold);

        float warningThreshold = currentTreshold * percentageWarning;

        if (v > 0 && v > currentTreshold + turbulance - warningThreshold)
        {
            gyroIndicator.ShowDangerRight(false);
            gyroIndicator.ShowDangerLeft(true);
            JeanPoilIsFalling.SetActive(true);
            JeanPoilIdle.SetActive(false);
        }
        else if (v < 0 && v < -currentTreshold + turbulance + warningThreshold)
        {
            gyroIndicator.ShowDangerLeft(false);
            gyroIndicator.ShowDangerRight(true);
            JeanPoilIsFalling.SetActive(true);
            JeanPoilIdle.SetActive(false);

        }
        else
        {
            gyroIndicator.ShowDangerLeft(false);
            gyroIndicator.ShowDangerRight(false);
            JeanPoilIsFalling.SetActive(false);
            JeanPoilIdle.SetActive(true);
        }

        if (!gameStarting)
        {
            if (v > 0 && v > currentTreshold + turbulance)
            {
                GameManager.Instance.deathEvent();
            }

            if (v < 0 && v < -currentTreshold + turbulance)
            {
                GameManager.Instance.deathEvent();
            }
        }
    }
}