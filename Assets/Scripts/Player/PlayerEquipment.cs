using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEquipment : MonoBehaviour
{
    [SerializeField]
    private PlayerStats pStats;

    public AItem equippedHelmet;
    public AItem equippedGloves;
    public AItem equippedWeapon;
    public AItem equippedBody;
    public AItem equippedLegs;
    public AItem equippedBoots;

    [SerializeField]
    private Image helmetImg;
    [SerializeField]
    private Image glovesImg;
    [SerializeField]
    private Image weaponImg;
    [SerializeField]
    private Image bodyImg;
    [SerializeField]
    private Image legsImg;
    [SerializeField]
    private Image bootsImg;

    [Header("Audio")]
    [SerializeField]
    private AudioClipFloatEvent audioEvent;
    [SerializeField]
    private AudioClipInfo equipSound;

    public void EquipItem(AItem item)
    {
        switch (item.type)
        {
            case ItemType.Body:
                EquipBody(item);
                break;
            case ItemType.Helmet:
                EquipHelmet(item);
                break;
            case ItemType.Weapon:
                EquipWeapon(item);
                break;
            case ItemType.Legs:
                EquipLegs(item);
                break;
            case ItemType.Boots:
                EquipBoots(item);
                break;
            case ItemType.Gloves:
                EquipGloves(item);
                break;
            default:
                break;
        }
        audioEvent.Raise(equipSound.clip, equipSound.targetVolume);
    }

    private void EquipBody(AItem item)
    {
        if (equippedBody)
        {
            foreach (var bonusStat in equippedBody.bonusStats)
            {
                bonusStat.RemoveStats(pStats);
            }
            pStats.inventory.AddItem(equippedBody);
        }
        equippedBody = item;
        bodyImg.sprite = item.inventorySprite;
        pStats.inventory.RemoveItem(item);
        foreach (var bonusStat in item.bonusStats)
        {
            bonusStat.ApplyStats(pStats);
        }
        bodyImg.color = Color.white;
    }
    private void EquipHelmet(AItem item)
    {
        if (equippedHelmet)
        {
            foreach (var bonusStat in equippedHelmet.bonusStats)
            {
                bonusStat.RemoveStats(pStats);
            }
            pStats.inventory.AddItem(equippedHelmet);
        }
        equippedHelmet = item;
        helmetImg.sprite = item.inventorySprite;
        pStats.inventory.RemoveItem(item);
        foreach (var bonusStat in item.bonusStats)
        {
            bonusStat.ApplyStats(pStats);
        }
        helmetImg.color = Color.white;
    }
    private void EquipWeapon(AItem item)
    {
        if (equippedWeapon)
        {
            foreach (var bonusStat in equippedWeapon.bonusStats)
            {
                bonusStat.RemoveStats(pStats);
            }
            pStats.inventory.AddItem(equippedWeapon);
        }
        equippedWeapon = item;
        weaponImg.sprite = item.inventorySprite;
        pStats.inventory.RemoveItem(item);
        foreach (var bonusStat in item.bonusStats)
        {
            bonusStat.ApplyStats(pStats);
        }
        weaponImg.color = Color.white;
    }
    private void EquipLegs(AItem item)
    {
        if (equippedLegs)
        {
            foreach (var bonusStat in equippedLegs.bonusStats)
            {
                bonusStat.RemoveStats(pStats);
            }
            pStats.inventory.AddItem(equippedLegs);
        }
        equippedLegs = item;
        legsImg.sprite = item.inventorySprite;
        pStats.inventory.RemoveItem(item);
        foreach (var bonusStat in item.bonusStats)
        {
            bonusStat.ApplyStats(pStats);
        }
        legsImg.color = Color.white;
    }
    private void EquipBoots(AItem item)
    {
        if (equippedBoots)
        {
            foreach (var bonusStat in equippedBoots.bonusStats)
            {
                bonusStat.RemoveStats(pStats);
            }
            pStats.inventory.AddItem(equippedBoots);
        }
        equippedBoots = item;
        bootsImg.sprite = item.inventorySprite;
        pStats.inventory.RemoveItem(item);
        foreach (var bonusStat in item.bonusStats)
        {
            bonusStat.ApplyStats(pStats);
        }
        bootsImg.color = Color.white;
    }
    private void EquipGloves(AItem item)
    {
        if (equippedGloves)
        {
            foreach (var bonusStat in equippedGloves.bonusStats)
            {
                bonusStat.RemoveStats(pStats);
            }
            pStats.inventory.AddItem(equippedGloves);
        }
        equippedGloves = item;
        glovesImg.sprite = item.inventorySprite;
        pStats.inventory.RemoveItem(item);
        foreach (var bonusStat in item.bonusStats)
        {
            bonusStat.ApplyStats(pStats);
        }
        glovesImg.color = Color.white;
    }
}
