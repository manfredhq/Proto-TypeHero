using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEditor;

public  class AItem : ScriptableObject
{
    public GameObject IGPrefab;
    public Sprite inventorySprite;
    public ItemType type;

    public List<AStats> bonusStats = new List<AStats>();

    public virtual object Clone() { throw new System.Exception("NOT IMPLEMENTED EXCEPTION"); }
    public void SetData(AItem item)
    {
        item.IGPrefab = IGPrefab;
        item.inventorySprite = inventorySprite;
        item.type = type;
        item.bonusStats = bonusStats;
    }
}


public enum ItemType
{
    Body,
    Helmet,
    Weapon,
    Legs,
    Boots,
    Gloves,
    Consumable
}

//[CustomEditor(typeof(AItem),true)]
//public class AItemEditro : Editor
//{
//    public override Texture2D RenderStaticPreview(string assetPath, Object[] subAssets, int width, int height)
//    {
//        var aitem = (AItem)target;

//        if(aitem == null || aitem.inventorySprite == null)
//        {
//            return null;
//        }

//        var texture = new Texture2D(width, height);
//        EditorUtility.CopySerialized(aitem.inventorySprite.texture, texture);
//        return texture;
//    }
//}
