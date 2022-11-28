using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverAnims : MonoBehaviour
{
    public GameObject Player;
    public int playerPos = 1;

    public GameObject Anims;
    public float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        time = 150;
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = Player.GetComponent<Deplacements>().positionPlayer;

        if(playerPos == 0)
        {
            Anims.transform.position = new Vector3(-2.72f, 5.33f, 2.48f);
        }
        if (playerPos == 1)
        {
            Anims.transform.position = new Vector3(-0.33f, 5.33f, 2.48f);
        }
        if (playerPos == 2)
        {
            Anims.transform.position = new Vector3(3.03f, 5.33f, 2.48f);
        }


        if (time > 0)
        {
            time = time - 1 * Time.deltaTime;
        }
        if(time < 1)
        {
            Anims.SetActive(false);
        }
    }
}
