using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UI_Shop : MonoBehaviour
{
    public TMPro.TMP_Text money;
    public UI_ShopItem[] shopItems;

    private void OnEnable()
    {
        money.text = AppController.Instance.Money + "$";

        CosmeticHolder.Instance.onBuyItem += UpdateView;
        CosmeticHolder.Instance.onEquipItem += UpdateView;
    }

    private void OnDisable()
    {
        CosmeticHolder.Instance.onBuyItem -= UpdateView;
        CosmeticHolder.Instance.onEquipItem -= UpdateView;
    }

    public void UpdateView(CosmeticItem item)
    {
        money.text = AppController.Instance.Money + "$";
        for (int i = 0; i < shopItems.Length; i++)
        {
            shopItems[i].UpdateState();
        }
    }
}
