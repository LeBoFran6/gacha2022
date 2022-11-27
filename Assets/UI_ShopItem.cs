using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ShopItem : MonoBehaviour
{
    public CosmeticItem cosmeticItem;
    public TMPro.TMP_Text title;
    public TMPro.TMP_Text description;
    public TMPro.TMP_Text price;
    public Image icon;
    public Button button;

    private void OnEnable()
    {
        title.text = cosmeticItem.itemName;
        description.text = cosmeticItem.description;
        icon.sprite = cosmeticItem.icon;
        if (cosmeticItem.unlocked)
        {
            if (cosmeticItem.equiped)
            {
                price.text = "Equiped";
                button.interactable = false;
            }
            else
            {
                price.text = "Equip";
                button.interactable = true;
            }
        }
        else
        {
            price.text = cosmeticItem.price + "$";
            button.interactable = true;
        }

        if (cosmeticItem.price > AppController.Instance.Money)
        {
            button.interactable = false;
        }
    }

    public void ClickOnButton()
    {
        if (cosmeticItem.unlocked)
        {
            if (!cosmeticItem.equiped)
            {
                CosmeticHolder.Instance.EquipeItem(cosmeticItem);
            }
        }
        else
        {
            AppController.Instance.BuyItem(cosmeticItem);
            CosmeticHolder.Instance.BuyItem(cosmeticItem);
            CosmeticHolder.Instance.EquipeItem(cosmeticItem);
        }
    }

    public void UpdateState()
    {
        OnEnable();
    }
}
