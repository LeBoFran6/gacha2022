using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New cosmetic", menuName = "Cosmetic")]
public class CosmeticItem : ScriptableObject
{
    public Type type;
    public string itemName;
    [TextArea]
    public string description;
    public Sprite icon;
    public Material prefab;
    public int price;
    public bool unlocked = false;
    public bool equiped = false;

    public bool defaultUnlocked = false;

    public string SaveName
    {
        get
        {
            return name + "_" + type.ToString();
        }
    }

    public void SaveAssetState()
    {
        PlayerPrefs.SetInt(SaveName, unlocked ? 1 : 0);
    }

    public void LoadAssetState(string e)
    {
        equiped = (SaveName == e);
        unlocked = PlayerPrefs.GetInt("Unlocked_" + SaveName, 0) == 1;
    }


    public enum Type
    {
        None,
        JeanPoil,
        Shredinger,
        Count ///PLZ LAST
    }
}
