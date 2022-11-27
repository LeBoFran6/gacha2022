using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CosmeticHolder : MonoBehaviour
{
    private static CosmeticHolder _instance;
    private CosmeticItem[] cosmeticItems;

    public CosmeticItem hat;
    public CosmeticItem jacket;

    public event OnItemDelegate onBuyItem;
    public event OnItemDelegate onEquipItem;
    public delegate void OnItemDelegate(CosmeticItem item);

    public static CosmeticHolder Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<CosmeticHolder>();

            return _instance;
        }
    }

    public void SaveGame()
    {
        for (int x = 0; x < cosmeticItems.Length; x++)
        {
            cosmeticItems[x].SaveAssetState();
        }
    }

    public void LoadGame()
    {
        cosmeticItems = Resources.LoadAll<CosmeticItem>("Objects/");

        for (CosmeticItem.Type i = 0; i < CosmeticItem.Type.Count; i++)
        {
            string equipedItem = PlayerPrefs.GetString("Equiped_" + i.ToString(), "");
            for (int x = 0; x < cosmeticItems.Length; x++)
            {
                if (cosmeticItems[x].type == i)
                {
                    cosmeticItems[x].LoadAssetState(equipedItem);
                    if (cosmeticItems[x].equiped)
                    {
                        EquipeItem(cosmeticItems[x]);
                    }
                }
            }
        }
    }

    public void EquipeItem(CosmeticItem item)
    {
        PlayerPrefs.SetString("Equiped_" + item.type.ToString(), item.SaveName);
        item.equiped = true;

        switch (item.type)
        {
            case CosmeticItem.Type.None:
                break;
            case CosmeticItem.Type.Hat:
                if(hat)
                    hat.equiped = false;
                hat = item;
                break;
            case CosmeticItem.Type.Jacket:
                if(jacket)
                    jacket.equiped = false;
                jacket = item;
                break;
            default:
                break;
        }

        if(onEquipItem != null)
            onEquipItem(item);
    }

    public void BuyItem(CosmeticItem item)
    {
        item.unlocked = true;
        PlayerPrefs.SetInt("Unlocked_" + item.SaveName, 1);

        if (onBuyItem != null)
            onBuyItem(item);
    }
}
