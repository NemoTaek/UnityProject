using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Object/ItemData")]
public class ItemData : ScriptableObject
{
    public enum ItemType { Active, Passive }

    [Header("----- Main Info -----")]
    public ItemType itemType;
    public int itemId;
    public string itemName;
    public int itemPrice;
    public string itemDesc;
    public float itemCoolTime;
    public float itemDuringTime;
    public Sprite itemImage;
}