using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deplacements : MonoBehaviour
{
    public Rigidbody rb;
    public bool G = false;
    public bool D = false;
    public int positionPlayer = 1;

    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;

    [SerializeField] private Vector3 startpos;
    [SerializeField] private Vector3 endpos;
    [SerializeField] private AnimationCurve curve;
    [SerializeField] private float percentage;
    private float dir = 1;

    private bool isJumping = false;

    public void Gauche()
    {
        G = true;
    }
    public void Droite()
    {
        D = true;
    }

    // Update is called once per frame
    void Update()
    { 
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPosition = Input.GetTouch(0).position;

            // Swipe vers le bas
            if (endTouchPosition.y < startTouchPosition.y)
            {
                
            }

            // Swipe vers le haut
            if (endTouchPosition.y > startTouchPosition.y)
            {
                isJumping = true;

                startpos = transform.position;
                endpos = transform.position + new Vector3(0, 3, 0);
            }
        }

        if (isJumping)
        {
            transform.position = Vector3.Lerp(startpos, endpos, curve.Evaluate(percentage));

            percentage += Time.deltaTime * dir;

            if (Time.deltaTime * dir > 1.0f || percentage < 0) { dir = -dir; }

            if (percentage > 1)
            {
                isJumping = false;
                percentage = 0;
            }
        }

        if (positionPlayer != 0)
        {
            if (G)
            {
                rb.velocity = new Vector3(-35, 0, 0);
                positionPlayer--;
                G = false;
            }
        }

        if (positionPlayer != 2)
        {
            if (D)
            {
                rb.velocity = new Vector3(35, 0, 0);
                positionPlayer++;
                D = false;
            }
        }
        D = false;
        G = false;
    }
}
