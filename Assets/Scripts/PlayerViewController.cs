using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerViewController : MonoBehaviour
{ 
    public Transform hatPlace;
    public Transform jacketPlace;

    private GameObject hat;
    private GameObject jacket;

    private void Start()
    {
        if (CosmeticHolder.Instance.hat)
        {
            //hat = Instantiate(CosmeticHolder.Instance.hat, hatPlace);
            hat.transform.localPosition = Vector3.zero;
            hat.transform.localRotation = Quaternion.identity;
        }

        if (CosmeticHolder.Instance.jacket)
        {
            //jacket = Instantiate(CosmeticHolder.Instance.jacket, jacketPlace);
            jacket.transform.localPosition = Vector3.zero;
            jacket.transform.localRotation = Quaternion.identity;
        }
    }
}
