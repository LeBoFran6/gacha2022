using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Experimental.Rendering.Universal;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject gameOverTextObject;
    [SerializeField] private RenderObjects URPRenderObjects;
    [SerializeField] private uint herbTreshold;
    [SerializeField] private uint globalHerbs;
    [SerializeField] private uint currentHerbs;

    private bool isAlive;

    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive)
        {
            gameOverTextObject.SetActive(true);
            player.SetActive(false);
        }

        if(currentHerbs == herbTreshold)
        {
            currentHerbs = 0;
            URPRenderObjects.SetActive(true);
            StartCoroutine(PsychoMode());
        }
    }

    public void deathEvent()
    {
        isAlive = false;
    }

    public void collectHerb()
    {
        globalHerbs++;
        currentHerbs++;
    }

    IEnumerator PsychoMode()
    {
        yield return new WaitForSeconds(3f);

        URPRenderObjects.SetActive(false);
    }
}
