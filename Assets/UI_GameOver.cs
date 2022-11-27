using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_GameOver : MonoBehaviour
{
    public TMP_Text score;
    public TMP_Text money;

    public Image[] stars;
    public Sprite completStar;

    public void ShowGameOver()
    {
        gameObject.SetActive(true);
    }
}
