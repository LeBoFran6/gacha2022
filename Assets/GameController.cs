using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    static GameController _instance;
    public static GameController Instance 
    { get 
        { 
            if(_instance == null)
                _instance = FindObjectOfType<GameController>();
            return _instance; 
        }
    }

    public int herbe = 0;
    public void AddHerbe()
    {
        herbe++;
    }

    public void LostHerbe()
    {
        herbe--;
    }
}
