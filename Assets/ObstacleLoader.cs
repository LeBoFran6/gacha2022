using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Unity.VisualScripting;

public class ObstacleLoader : MonoBehaviour
{
    [SerializeField] private Object fileRef;

    [SerializeField] private GameObject rootObstacles;
    [SerializeField] private GameObject rootCollectibles;

    [SerializeField] private List<GameObject> propsFrontObstacles;
    [SerializeField] private List<GameObject> propsJumpObstacles;
    [SerializeField] private List<GameObject> propsCrouchObstacles;
    [SerializeField] private GameObject propHerb;

    [SerializeField] private Vector3 leftSpawnerPos;
    [SerializeField] private Vector3 midSpawnerPos;
    [SerializeField] private Vector3 rightSpawnerPos;

    [SerializeField] private float deltaPos;

    private float currentGap = 0;

    private byte[] dataArray = new byte[10000];

    // Start is called before the first frame update
    void Start()
    {
        TextAsset t = Resources.Load<TextAsset>("Level Design/" + fileRef.name);
        dataArray = t.bytes;


            int inter = 6;

#if UNITY_EDITOR_WIN
            inter = 7;
#endif

            for (int i = 0; i < dataArray.Length; i += inter)
            {
                int randPropId;

                switch(dataArray[i])
                {
                    case (byte)'X': break;

                    case (byte)'H': Instantiate(propHerb, leftSpawnerPos + new Vector3(0, 0.5f, currentGap), propHerb.transform.rotation, rootCollectibles.transform); break;

                    case (byte)'F': randPropId = Random.Range(0,propsFrontObstacles.Count);  Instantiate(propsFrontObstacles[randPropId], leftSpawnerPos + new Vector3(0, 0, currentGap), Quaternion.identity, rootObstacles.transform); break;

                    case (byte)'J': randPropId = Random.Range(0,propsJumpObstacles.Count); Instantiate(propsJumpObstacles[randPropId], leftSpawnerPos + new Vector3(0, 0, currentGap), Quaternion.identity, rootObstacles.transform); break;

                    case (byte)'C': randPropId = Random.Range(0,propsCrouchObstacles.Count); Instantiate(propsCrouchObstacles[randPropId], leftSpawnerPos + new Vector3(0, 0, currentGap), Quaternion.identity, rootObstacles.transform); break;

                    default: Debug.Log("Parsing error : " + (char)dataArray[i]); break;
                }

                switch (dataArray[i+2])
                {
                    case (byte)'X': break;

                    case (byte)'H': Instantiate(propHerb, midSpawnerPos + new Vector3(0, 0.5f, currentGap), propHerb.transform.rotation, rootCollectibles.transform); break;

                    case (byte)'F': randPropId = Random.Range(0, propsFrontObstacles.Count); Instantiate(propsFrontObstacles[randPropId], midSpawnerPos + new Vector3(0, 0, currentGap), Quaternion.identity, rootObstacles.transform); break;

                    case (byte)'J': randPropId = Random.Range(0, propsJumpObstacles.Count); Instantiate(propsJumpObstacles[randPropId], midSpawnerPos + new Vector3(0, 0, currentGap), Quaternion.identity, rootObstacles.transform); break;

                    case (byte)'C': randPropId = Random.Range(0, propsCrouchObstacles.Count); Instantiate(propsCrouchObstacles[randPropId], midSpawnerPos + new Vector3(0, 0, currentGap), Quaternion.identity, rootObstacles.transform); break;

                    default: Debug.Log("Parsing error : " + (char)dataArray[i]); break;
                }

                switch (dataArray[i+4])
                {
                    case (byte)'X': break;

                    case (byte)'H': Instantiate(propHerb, rightSpawnerPos + new Vector3(0, 0.5f, currentGap), propHerb.transform.rotation, rootCollectibles.transform); break;

                    case (byte)'F': randPropId = Random.Range(0, propsFrontObstacles.Count); Instantiate(propsFrontObstacles[randPropId], rightSpawnerPos + new Vector3(0, 0, currentGap), Quaternion.identity, rootObstacles.transform); break;

                    case (byte)'J': randPropId = Random.Range(0, propsJumpObstacles.Count); Instantiate(propsJumpObstacles[randPropId], rightSpawnerPos + new Vector3(0, 0, currentGap), Quaternion.identity, rootObstacles.transform); break;

                    case (byte)'C': randPropId = Random.Range(0, propsCrouchObstacles.Count); Instantiate(propsCrouchObstacles[randPropId], rightSpawnerPos + new Vector3(0, 0, currentGap), Quaternion.identity, rootObstacles.transform); break;

                    default: Debug.Log("Parsing error : " + (char)dataArray[i]); break;
                }

                currentGap += deltaPos;
            }
    }
}
