using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterSheetUI : MonoBehaviour
{

    [SerializeField]
    private Image panelImage;

    [SerializeField]
    private Image statsPanelimage;


    [SerializeField]
    private List<TMP_Text> statsTexts;

    [SerializeField]
    private Image helmetImage;

    [SerializeField]
    private Image shouldersImage;

    [SerializeField]
    private Image weaponImage;

    [SerializeField]
    private Image bodyImage;

    [SerializeField]
    private Image legsImage;

    [SerializeField]
    private Image bootsImage;

    [SerializeField]
    private Image helmetImageBG;

    [SerializeField]
    private Image shouldersImageBG;

    [SerializeField]
    private Image weaponImageBG;

    [SerializeField]
    private Image bodyImageBG;

    [SerializeField]
    private Image legsImageBG;

    [SerializeField]
    private Image bootsImageBG;

    [SerializeField]
    private PlayerEquipment playerEquipment;

    private void Start()
    {
        panelImage.color = new Color(1,1,1,0);
        statsPanelimage.color = new Color(1,1,1,0);
        foreach (var statsText in statsTexts)
        {
            statsText.color = new Color(0, 0, 0, 0);
        }
        helmetImageBG.color = new Color(1,1,1,0);
        shouldersImageBG.color = new Color(1,1,1,0);
        weaponImageBG.color = new Color(1,1,1,0);
        bodyImageBG.color = new Color(1,1,1,0);
        legsImageBG.color = new Color(1,1,1,0);
        bootsImageBG.color = new Color(1,1,1,0);
    }

    public void OnOpenCharacterSheet()
    {
        //prevents bug if we fade out during fade in. // Stop fading in if we enter combat
        StopAllCoroutines();

        helmetImage.sprite = playerEquipment.equippedHelmet?.inventorySprite;
        shouldersImage.sprite = playerEquipment.equippedGloves?.inventorySprite;
        weaponImage.sprite = playerEquipment.equippedWeapon?.inventorySprite;
        bodyImage.sprite = playerEquipment.equippedBody?.inventorySprite;
        legsImage.sprite = playerEquipment.equippedLegs?.inventorySprite;
        bootsImage.sprite = playerEquipment.equippedBoots?.inventorySprite;



        StartCoroutine(FadeManager.FadeIn(panelImage, 1f));
        StartCoroutine(FadeManager.FadeIn(statsPanelimage, 1f));
        foreach (var statsText in statsTexts)
        {
            StartCoroutine(FadeManager.FadeIn(statsText, 1f));
        }
        StartCoroutine(FadeManager.FadeIn(helmetImageBG, 1f));
        StartCoroutine(FadeManager.FadeIn(shouldersImageBG, 1f));
        StartCoroutine(FadeManager.FadeIn(weaponImageBG, 1f));
        StartCoroutine(FadeManager.FadeIn(bodyImageBG, 1f));
        StartCoroutine(FadeManager.FadeIn(legsImageBG, 1f));
        StartCoroutine(FadeManager.FadeIn(bootsImageBG, 1f));

        if(playerEquipment.equippedHelmet)
            StartCoroutine(FadeManager.FadeIn(helmetImage, 1f));
        if (playerEquipment.equippedGloves)
            StartCoroutine(FadeManager.FadeIn(shouldersImage, 1f));
        if (playerEquipment.equippedWeapon)
            StartCoroutine(FadeManager.FadeIn(weaponImage, 1f));
        if (playerEquipment.equippedBody)
            StartCoroutine(FadeManager.FadeIn(bodyImage, 1f));
        if (playerEquipment.equippedLegs)
            StartCoroutine(FadeManager.FadeIn(legsImage, 1f));
        if (playerEquipment.equippedBoots)
            StartCoroutine(FadeManager.FadeIn(bootsImage, 1f));
    }

    public void OnCloseCharacterSheet()
    {
        //prevents bug if we fade out during fade in. // Stop fading in if we enter combat
        StopAllCoroutines();

        StartCoroutine(FadeManager.FadeOut(panelImage, 1f));
        StartCoroutine(FadeManager.FadeOut(statsPanelimage, 1f));
        foreach (var statsText in statsTexts)
        {
            StartCoroutine(FadeManager.FadeOut(statsText, 1f));
        }
        StartCoroutine(FadeManager.FadeOut(helmetImage, 2f));
        StartCoroutine(FadeManager.FadeOut(shouldersImage, 2f));
        StartCoroutine(FadeManager.FadeOut(weaponImage, 2f));
        StartCoroutine(FadeManager.FadeOut(bodyImage, 2f));
        StartCoroutine(FadeManager.FadeOut(legsImage, 2f));
        StartCoroutine(FadeManager.FadeOut(bootsImage, 2f));
        StartCoroutine(FadeManager.FadeOut(helmetImageBG, 2f));
        StartCoroutine(FadeManager.FadeOut(shouldersImageBG, 2f));
        StartCoroutine(FadeManager.FadeOut(weaponImageBG, 2f));
        StartCoroutine(FadeManager.FadeOut(bodyImageBG, 2f));
        StartCoroutine(FadeManager.FadeOut(legsImageBG, 2f));
        StartCoroutine(FadeManager.FadeOut(bootsImageBG, 2f));
    }

    
}
