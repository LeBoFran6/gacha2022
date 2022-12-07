using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deplacements : MonoBehaviour
{
    public Transform[] positions;

    public int positionPlayer = 1;

    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;

    [SerializeField] private Vector3 startpos;
    [SerializeField] private Vector3 endpos;
    [SerializeField] private AnimationCurve curve;
    [SerializeField] private AnimationCurve curveSlide;
    [SerializeField] private float percentage1;
    [SerializeField] private float percentage2;
    private float dir = 1;

    private bool isJumping = false;
    private bool isSliding = false;

    [SerializeField]
    private GyroScript gyroScript;

    private float currentPitch = 0;
    public float targetPitch = 0;

    public Balance balance;

    public void Gauche()
    {
        if (!isSliding && !isJumping && positionPlayer >= 1)
        {
            positionPlayer--;
        }
    }
    public void Droite()
    {
        if (!isSliding && !isJumping && positionPlayer <= 1)
        {
            positionPlayer++;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && isSliding == false && isJumping == false)
        {
            isSliding = true;
            currentPitch = 0;

            startpos = transform.position;
            endpos = transform.position + new Vector3(0, -0.5f, 0);
        }

        if (Input.GetKeyDown("space") && isJumping == false && isSliding == false)
        {
            isJumping = true;

            startpos = transform.position;
            endpos = transform.position + new Vector3(0, 3, 0);
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPosition = Input.GetTouch(0).position;

            // Swipe vers le bas
            if (endTouchPosition.y < startTouchPosition.y && isSliding == false && isJumping == false)
            {
                isSliding = true;
                currentPitch = 0;

                startpos = transform.position;
                endpos = transform.position + new Vector3(0, -0.5f, 0);
                
            }

            // Swipe vers le haut
            if (endTouchPosition.y > startTouchPosition.y && isJumping == false && isSliding == false)
            {
                isJumping = true;

                startpos = transform.position;
                endpos = transform.position + new Vector3(0, 3, 0);

            }
        }

        if (isSliding && !isJumping)
        {
            currentPitch = Mathf.LerpUnclamped(0, targetPitch, curveSlide.Evaluate(percentage1));
            gyroScript.pitch = currentPitch;
            transform.position = Vector3.LerpUnclamped(startpos, endpos, curve.Evaluate(percentage1));
            percentage1 += Time.deltaTime;

            if (percentage1 > 1)
            {
                isSliding = false;
                percentage1 = 0;
            }
        }

        if (isJumping && !isSliding)
        {
            transform.position = Vector3.Lerp(startpos, endpos, curve.Evaluate(percentage2));

            percentage2 += Time.deltaTime * dir;

            if (Time.deltaTime * dir > 1.0f || percentage2 < 0) { dir = -dir; }

            if (percentage2 > 1)
            {
                isJumping = false;
                percentage2 = 0;
            }
        }

        transform.position = new Vector3(Mathf.Lerp(transform.position.x, positions[positionPlayer].position.x, 0.1f),transform.position.y,transform.position.z);
    }
}
