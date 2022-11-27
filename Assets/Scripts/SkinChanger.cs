using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinChanger : MonoBehaviour
{
    public Material skin;

    private void Awake()
    {
        //Change the Player view controller parent skin
        MeshRenderer render = transform.parent.parent.GetComponent<MeshRenderer>();
        render.material = skin;
    }
}
