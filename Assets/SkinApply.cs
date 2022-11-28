using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinApply : MonoBehaviour
{
    public CosmeticItem.Type Type;
    public MeshRenderer[] renders;

    void Start()
    {
        CosmeticItem c = null;

        switch (Type)
        {
            case CosmeticItem.Type.JeanPoil:
                c = CosmeticHolder.Instance.jacket;
                break;
            case CosmeticItem.Type.Shredinger:
                c = CosmeticHolder.Instance.hat;
                break;
            default:
                break;
        }

        if (c != null)
        {

            for (int i = 0; i < renders.Length; i++)
            {
                renders[i].material = c.prefab;
            }

        }
    }
}
